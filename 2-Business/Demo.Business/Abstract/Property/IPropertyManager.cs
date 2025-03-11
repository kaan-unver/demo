using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.Utilities.Results;

namespace Demo.Business.Abstract.Property
{
    public interface IPropertyManager
    {
        IResult IsRequiredCaptchaControl();
        IDataResult<string> GetSourcePreviewUrl();
        IDataResult<string> GetDefaultLangu();
        IDataResult<string> GetComponentTheme();
        IDataResult<string> GetLayoutTheme();
        IDataResult<string> GetColorScheme();
        IDataResult<string> GetMenuType();
        IDataResult<bool> GetRippleEffect();
        IDataResult<int> GetSecondsDefinedToDeleteActionFromRedis();
        IDataResult<int> GetMaxRequestCountForEachAction();
        IDataResult<T> GetValueByKey<T>(string key, string defaultValue, CultureInfo? cultureInfo = null) where T : IParsable<T>;
    }
}
