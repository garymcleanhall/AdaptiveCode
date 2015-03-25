using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.Contracts
{
    public interface IApplicationSettings
    {
        string GetValue(string setting);
    }
}
