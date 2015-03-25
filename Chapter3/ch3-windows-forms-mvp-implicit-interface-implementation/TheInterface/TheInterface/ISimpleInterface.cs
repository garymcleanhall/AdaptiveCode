using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public interface ISimpleInterface
    {
        void ThisMethodRequiresImplementation();

        string ThisStringPropertyNeedsImplementingToo
        {
            get;
            set;
        }

        int ThisIntegerPropertyOnlyNeedsAGetter
        {
            get;
        }

        event EventHandler<EventArgs> InterfacesCanContainEventsToo;
    }
}
