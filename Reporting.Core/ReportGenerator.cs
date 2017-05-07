﻿using System.IO;

namespace Reporting
{
    public class ReportGenerator: IReportGenerator
    {
        private readonly IFileSystem fileSystem;
        private readonly ITemplateProvider templateProvider;

        public ReportGenerator(IFileSystem fileSystem, ITemplateProvider templateProvider)
        {
            this.fileSystem = fileSystem;
            this.templateProvider = templateProvider;
        }

        public void GenerateReport(TextReader input, string path)
        {
            var transformer = new XsltTransformer(templateProvider.GetIndexTemplate());
            using (var writer = fileSystem.CreateFile(path))
            {
                transformer.Transform(input, writer);
            }
        }
    }
}
