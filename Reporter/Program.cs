using Reporting.Configuration;

namespace Reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Args(args);
            var templateName = arguments.Has("template") ?
                arguments.One<string>("template") :
                "";
            var inputPath = arguments.Unnamed<string>();
            var outputPath = arguments.One<string>("output");

            var fs = new FileSystem();
            var templateProvider = new TemplateProvider(templateName);
            var generator = new ReportGenerator(fs, templateProvider);

            using (var input = fs.OpenFile(inputPath[0]))
            {
                generator.GenerateReport(input, outputPath);
            }
        }
    }
}
