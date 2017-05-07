using System;
using System.IO;

namespace Reporting.Fakes
{
    class FakeTemplateProvider : ITemplateProvider  
    {
        private readonly TextReader indexTemplate;

        public FakeTemplateProvider(TextReader indexTemplate)
        {
            this.indexTemplate = indexTemplate;
        }

        public TextReader GetTemplateReader()
        {
            return indexTemplate;
        }
    }
}