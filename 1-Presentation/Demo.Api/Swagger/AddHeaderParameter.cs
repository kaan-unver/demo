using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace Demo.Api.Swagger
{

    public class AddHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-VerifyKey",
                In = ParameterLocation.Header,

                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }


    }

}
