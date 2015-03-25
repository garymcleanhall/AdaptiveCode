using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtypeCovariance
{
    public class User : Entity
    {
        public string EmailAddress { get; private set; }

        public DateTime DateOfBirth { get; private set; }
    }
}
