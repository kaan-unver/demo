using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.OpenApi.Models;
using NLog;
using Demo.Api.IoC;
using Demo.Business.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Demo.Api.Middlewares;
using Demo.Api.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Demo.Core.Utilities.Extensions;
using Demo.Core.Logging;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Demo.Api.Helper;

var builder = WebApplication.CreateBuilder(args);

//FluentValidation yapısı için gerekli
builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Example: 'Bearer 12345abcdef'",
        Name = "X-Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "jwt",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });
    //headerdan ek bir parametre almak istersek kullanırız
    c.OperationFilter<AddHeaderParameter>();
});

LogManager.Setup().LoadConfigurationFromFile($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}AppConfig{Path.DirectorySeparatorChar}nlog.config");
builder.Services.AddAutoMapper(typeof(MapProfile));

//autofac container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

//HttpContext e erişmek amacıyla 
builder.Services.AddHttpContextAccessor();
//inmemorycache kullanmak amacıyla
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader();
        //.WithOrigins("http://localhost:3000")
        //     .AllowAnyMethod()
        //              .AllowAnyHeader(); ;
    });
});
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});

var app = builder.Build();
app.UseCustomException(new NLogManager());
var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var supportedCultures = new[] { cultureInfo };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultureInfo),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});
var corsPolicyProvider = app.Services.GetRequiredService<ICorsPolicyProvider>();
var corsService = app.Services.GetRequiredService<ICorsService>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
//app.UseCors(builder => builder
//                .AllowAnyOrigin()
//                .AllowAnyMethod()
//                .AllowAnyOrigin()
//                .AllowAnyHeader()
//           //.AllowAnyHeader()
//           //.WithMethods("GET", "POST", "PUT")
//           // .SetIsOriginAllowed((host) => true)
//           //.AllowCredentials()


var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "_Uploads");
if (!Directory.Exists(uploadsPath))
    Directory.CreateDirectory(uploadsPath);


app.UseStaticFiles(new StaticFileOptions
{

    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "_Uploads")),
    RequestPath = "/_Uploads",
    OnPrepareResponse = async (ctx) =>
    {
        var policy = await corsPolicyProvider.GetPolicyAsync(ctx.Context, "CorsPolicy");
        if (policy != null)
        {
            var corsResult = corsService.EvaluatePolicy(ctx.Context, policy);
            corsService.ApplyResult(corsResult, ctx.Context.Response);
        }
    }
});


app.UseRouting();
app.UseCors("CorsPolicy");


app.UseMiddleware<HttpMethodValidationMiddleware>();
app.UseMiddleware<EndpointMiddleware>(); //Getting token type and transfer it through context items
app.UseAuthorization();
app.UseMiddleware<TokenMiddleware>(); //Checking token type 


app.UseRequestLocalization();
app.MapControllers();

app.Run();


