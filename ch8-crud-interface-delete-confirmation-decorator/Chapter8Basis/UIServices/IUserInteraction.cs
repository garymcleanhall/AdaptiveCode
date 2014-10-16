using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIServices
{
    public interface IUserInteraction
    {
        bool Confirm(string message);
    }
}
