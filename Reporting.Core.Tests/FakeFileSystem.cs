using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Reporting
{
    class FakeFileSystem : IFileSystem
    {
        private readonly Dictionary<string, StringWriter> files =
            new Dictionary<string, StringWriter>();

        public IDictionary<string, string> Files
        {
            get
            {
                return files
                    .Select(x => new
                    {
                        Key = x.Key,
                        Value = x.Value != null ?
                            x.Value.GetStringBuilder().ToString() :
                            string.Empty
                    })
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }

        public TextWriter CreateFile(string path)
        {
            var writer = new StringWriter();
            files.Add(path, writer);
            return writer;
        }
    }
}