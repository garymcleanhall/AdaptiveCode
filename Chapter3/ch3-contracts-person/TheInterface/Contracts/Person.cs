using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Person
    {
        public Person(int height, string name)
        {
            Contract.Requires<ArgumentOutOfRangeException>(height > 1);
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(name));

            Height = height;
            Name = name;
        }

        public int Height
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }
    }
}
