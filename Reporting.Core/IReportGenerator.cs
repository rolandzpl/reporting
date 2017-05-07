using System.IO;

namespace Reporting
{
    public interface IReportGenerator
    {
        void GenerateReport(TextReader input, string path);
    }
}