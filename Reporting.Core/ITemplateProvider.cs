using System.IO;

namespace Reporting
{
    public interface ITemplateProvider
    {
        TextReader GetIndexTemplate();
    }
}
