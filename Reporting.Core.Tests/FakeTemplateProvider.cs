using System;
using System.IO;

namespace Reporting
{
    class FakeTemplateProvider : ITemplateProvider  
    {
        private readonly TextReader indexTemplate;

        public FakeTemplateProvider(TextReader indexTemplate)
        {
            this.indexTemplate = indexTemplate;
        }

        public TextReader GetIndexTemplate()
        {
            return indexTemplate;
        }
    }
}