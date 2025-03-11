using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace Demo.Api.Helper
{
  

    public class CustomDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
            {
                return new CustomDecimalModelBinder();
            }
            return null;
        }
    }

}
