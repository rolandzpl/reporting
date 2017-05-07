using System;
using System.IO;

namespace Reporting
{
    class FileSystem: IFileSystem
    {
        public TextWriter CreateFile(string path)
        {
            return File.CreateText(path);
        }

        public TextReader OpenFile(string path)
        {
            return File.OpenText(path);
        }
    }
}