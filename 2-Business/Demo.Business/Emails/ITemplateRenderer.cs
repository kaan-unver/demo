using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business.Emails
{
    public interface ITemplateRenderer
    {
        Task<string> RenderTemplateAsync<TModel>(string templatePath, TModel model);
    }
}
