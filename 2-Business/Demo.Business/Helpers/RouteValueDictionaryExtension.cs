using Microsoft.AspNetCore.Routing;

namespace Demo.Core.Utilities.Extensions
{
    public static class RouteValueDictionaryExtension
    {
        public static string GetRequestedPath (this RouteValueDictionary keyValuePairs, IFormatProvider? provider = null)
        {
            string controllerName = keyValuePairs["controller"].ToString();
            string actionName = keyValuePairs["action"].ToString();
            

            return $"/api/{controllerName}/{actionName}";
        }
    }
}