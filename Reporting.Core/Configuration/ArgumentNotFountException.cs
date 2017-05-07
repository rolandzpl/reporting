using System;

namespace Reporting.Configuration
{
    public class ArgumentNotFountException : Exception
    {
        public ArgumentNotFountException(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}