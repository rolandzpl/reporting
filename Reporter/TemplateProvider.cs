using System.IO;
using System.Reflection;

namespace Reporting
{
    class TemplateProvider : ITemplateProvider
    {
        private readonly string templateName;

        public TemplateProvider(string templateName)
        {
            this.templateName = templateName;
        }

        public TextReader GetTemplateReader()
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = @"Reporting.Transformations." + templateName + ".xslt";
            var stream = asm.GetManifestResourceStream(name);
            return new StreamReader(stream);
        }
    }
}