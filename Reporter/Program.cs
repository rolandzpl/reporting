using System.IO;
using System.Linq;
using System.Reflection;

namespace Reporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var template = args
                .SingleOrDefault(x => x.StartsWith("--template="))
                .Split('=')
                .Skip(1)
                .FirstOrDefault();

            var asm = Assembly.GetExecutingAssembly();
            var stream = asm.GetManifestResourceStream(@"Reporter\" + template + "xslt");
            var xslt = new StreamReader(stream);
        }
    }
}
