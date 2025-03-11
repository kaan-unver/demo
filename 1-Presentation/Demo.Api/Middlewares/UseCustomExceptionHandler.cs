using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using Demo.Business.Abstract.Messages;
using Demo.Business.Exceptions;
using Demo.Core.Constants;
using Demo.Core.Logging;
using Demo.Core.Utilities.Results;

namespace Demo.Api.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app, ILogManager logger)
        {
          var messageManager =  app.ApplicationServices.GetRequiredService<IMessageManager>();
            app.UseExceptionHandler(config =>
            {
              
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => Constants.BadRequest,
                        NotFoundException => Constants.NotFound,
                        UnAuthorizedException => Constants.UnAuthorized,
                        MethodNotAllowedException => Constants.MethodNotAllowed,
                        UnAuthorizedExceptionForEndpoint => Constants.UnAuthorizedForEndpoint,
                        CaptchaUnVerifiedException => Constants.CaptchaUnVerified,
                        _ => Constants.NotImplemented
                    };

                    var message = exceptionFeature.Error.Message;
                    var transactionId = context.Items["TransactionId"]?.ToString();
                    var errorPair = new Dictionary<string, string> { { "TransactionId", transactionId! } };

                    var messageCode = context.Items["MessageCodeForRequest"]?.ToString();

                    if (statusCode == Constants.NotImplemented)
                    {
                        String errorMessage = exceptionFeature.Error.Message + "\n\n StackTrace:" + exceptionFeature.Error.StackTrace;
                        Exception? innerEx = exceptionFeature.Error.InnerException;
                        while (innerEx != null)
                        {
                            errorMessage += "\n\n" + innerEx.Message + "\n\n StackTrace:" + innerEx.StackTrace;
                            innerEx = innerEx.InnerException;
                        }
                        logger.Error(errorMessage, errorPair);
                        message =MessageCodes.InternalServerError;
                        statusCode = Constants.InternalServer;
                    }
                    else
                        logger.Error(message, errorPair);

                  
                    context.Response.StatusCode = statusCode;
                    var error = new ErrorResult(statusCode, messageCode, transactionId, message);
                    var response = (JsonSerializer.Serialize(error, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    }));
                    await context.Response.WriteAsync(response);
                });
            });
        }
    }
}
