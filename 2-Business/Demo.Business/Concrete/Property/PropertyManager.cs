using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Business.Abstract.Property;
using Demo.Core.Constants;
using Demo.Core.Utilities.Results;
using Demo.Infrastructure.Abstract.Property;

namespace Demo.Business.Concrete.Property
{
    internal class PropertyManager : IPropertyManager
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyManager(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }      
        public IDataResult<string> GetSourcePreviewUrl()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.SourcePreviewUrl);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }

        public IDataResult<string> GetDefaultLangu()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.DefaultLangu);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }
        public IDataResult<string> GetComponentTheme()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.ComponentTheme);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }
        public IDataResult<string> GetLayoutTheme()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.LayoutTheme);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }
        public IDataResult<string> GetColorScheme()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.ColorScheme);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }
        public IDataResult<string> GetMenuType()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.MenuType);
            if (value != null)
                return new SuccessDataResult<string>(value.ToString());

            return new ErrorDataResult<string>();
        }
        public IDataResult<bool> GetRippleEffect()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.RippleEffect);
            if (value != null)
                return new SuccessDataResult<bool>(Convert.ToBoolean(value));

            return new ErrorDataResult<bool>();
        }


        public IDataResult<int> GetMaxRequestCountForEachAction()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.MaxRequestCountForAction);
            if (value != null)
                return new SuccessDataResult<int>(int.Parse(value.ToString()!), Constants.Ok);
            return new ErrorDataResult<int>();
        }
        public IDataResult<int> GetSecondsDefinedToDeleteActionFromRedis()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.SecondsDefinedToDeleteActionFromRedis);
            if (value != null)
                return new SuccessDataResult<int>(int.Parse(value.ToString()!), Constants.Ok);
            return new ErrorDataResult<int>();
        }

        public IResult IsRequiredCaptchaControl()
        {
            var value = _propertyRepository.GetValueByKey(Defaults.Property.CaptchaPropertyKey);
            if (value != null && bool.Parse(value.ToString()!))
                return new SuccessResult();

            return new ErrorResult();
        }
       

        public IDataResult<T> GetValueByKey<T>(string key, string defaultValue, CultureInfo? cultureInfo = null) where T : IParsable<T>
        {
            var value = _propertyRepository.GetValueByKey<T>(key, defaultValue, cultureInfo);

            return new SuccessDataResult<T>(value, Constants.Ok);
        }
    }
}