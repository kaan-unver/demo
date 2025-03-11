using System.Globalization;
using Demo.Core.DataAccess.EntityFramework;
using Demo.Infrastructure.Abstract.Property;
using Demo.Infrastructure.Context;

namespace Demo.Infrastructure.Concrete.EF.Property
{
    internal class PropertyRepository : EfEntityRepositoryBase<Entities.Models.Property, DemoContext>, IPropertyRepository
    {
        public object? GetValueByKey(string key)
        {
            using var context = new DemoContext();
            {
                var property = context.Properties.SingleOrDefault(p => p.Key == key && !p.IsDeleted);
                if (property == null)
                    return null;
                return property.Value;
            }
        }

        public T GetValueByKey<T>(string key, string defaultValue, CultureInfo? cultureInfo = null) where T : IParsable<T>
        {
            var tmpValue = GetValueByKey(key);
            object result = tmpValue;
            if (tmpValue == null && defaultValue != null)
            {
                result = defaultValue;
            }

            cultureInfo ??= CultureInfo.InvariantCulture; // cultureInfo null ise, varsayılan olarak InvariantCulture kullanılır.

            return (T)Convert.ChangeType(result, typeof(T), cultureInfo);
        }
    }
}
