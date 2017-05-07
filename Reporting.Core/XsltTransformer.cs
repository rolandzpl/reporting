using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Reporting
{
    public class XsltTransformer
    {
        private TextReader xslt;

        public XsltTransformer(TextReader xslt)
        {
            this.xslt = xslt;
        }

        public void Transform(TextReader input, TextWriter output)
        {
            var xpath = new XPathDocument(input);
            var transform = new XslCompiledTransform();
            using(var reader = new XmlTextReader(xslt))
            {
                transform.Load(reader);
            }
            transform.Transform(xpath, null, output);
        }
    }
}