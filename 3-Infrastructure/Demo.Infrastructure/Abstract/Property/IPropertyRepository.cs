using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Core.DataAccess.EntityFramework;
using Demo.Core.Models;

namespace Demo.Infrastructure.Abstract.Property
{
    public interface IPropertyRepository : IEntityRepository<Entities.Models.Property>
    {
        object? GetValueByKey(string key);
        T GetValueByKey<T>(string key, string defaultValue, CultureInfo? culture = null) where T : IParsable<T>;
    }
}
