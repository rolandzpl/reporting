using System.IO;

namespace Reporting
{
    public interface IFileSystem
    {
        TextWriter CreateFile(string path);
    }
}