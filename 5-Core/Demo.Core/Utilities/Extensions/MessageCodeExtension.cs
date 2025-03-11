using Demo.Core.Constants;

namespace Demo.Core.Utilities.Extensions
{
    public static class MessageCodeExtension
    {
        public static string GetMessageCode(this string controllerName, string methodName)
        {

            var moduleInfo = typeof(ModuleMessageCodes).GetFields().Where(f => f.Name.ToLower() == controllerName.ToLower()).SingleOrDefault();
            if (moduleInfo == null)
                return controllerName;

            var methodInfo = typeof(MethodMessagesCodes).GetFields().Where(f => f.Name.ToLower() == methodName.ToLower()).SingleOrDefault();
            if (methodInfo == null)
                return controllerName;
            //TODO: Gülsüm ilgili controller ya da methoda ait constant tanımlanmamış olursa bu kısım patlar mı kontrol et. Yukarıdaki kontroller yakalamalı 
            //TODO: gülsüm bu kısmı düzenleyeceğim şuan yayına atılan kod patlar diye bu şekilde bıraktım
            var moduleCode = int.Parse(moduleInfo.GetRawConstantValue().ToString());
            var methodCode = (int)methodInfo.GetRawConstantValue();

            return (moduleCode + methodCode).ToString();
        }
    }
}
