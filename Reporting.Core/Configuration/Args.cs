using System;
using System.Linq;

namespace Reporting.Configuration
{
    public class Args
    {
        private readonly string[] args;

        public Args(params string[] args)
        {
            this.args = args;
        }

        public T One<T>(string name)
        {
            var s = args
                .SingleOrDefault(x => x.StartsWith("--" + name + "="));

            if (s == null)
            {
                throw new ArgumentNotFountException(name);
            }

            s = s
                .Split('=')
                .Skip(1)
                .FirstOrDefault();

            return (T)Convert.ChangeType(s, typeof(T));
        }

        public bool Switch(string name)
        {
            var s = args
                .SingleOrDefault(x => x.StartsWith("--" + name));

            if (s == null)
            {
                return false;
            }

            return true;
        }

        public T[] Many<T>(string name)
        {
            var s = args
                .Where(x => x.StartsWith("--" + name + "="))
                .ToArray();

            if (!s.Any())
            {
                throw new ArgumentNotFountException(name);
            }

            return s
                .Select(x => x.Split('=').Skip(1).SingleOrDefault())
                .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }

        public bool Has(string name)
        {
            return args.Any(x => x.StartsWith("--" + name + "="));
        }

        public T[] Unnamed<T>()
        {
            var s = args
                .Where(x => !x.StartsWith("--"))
                .ToArray();

            return s
                .Select(x => (T)Convert.ChangeType(x, typeof(T)))
                .ToArray();
        }
    }
}
