using RazorLight;

namespace Demo.Business.Emails
{
    public class RazorTemplateRenderer : ITemplateRenderer
    {
        private readonly RazorLightEngine _engine;

        public RazorTemplateRenderer()
        {
            var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Emails", "Templates");
            _engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(templatePath)
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task<string> RenderTemplateAsync<TModel>(string templateName, TModel model)
        {
            try
            {
                //var template = await File.ReadAllTextAsync(templatePath);
                //return await _engine.CompileRenderStringAsync(templatePath, template, model);
                return await _engine.CompileRenderAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, templateName), model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
