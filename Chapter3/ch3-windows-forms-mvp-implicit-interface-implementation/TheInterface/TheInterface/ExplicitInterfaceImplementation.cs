using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ExplicitInterfaceImplementation : ISimpleInterface
    {
        public ExplicitInterfaceImplementation()
        {
            this.encapsulatedInteger = 4;
        }

        void ISimpleInterface.ThisMethodRequiresImplementation()
        {
            encapsulatedEvent(this, EventArgs.Empty);
        }

        string ISimpleInterface.ThisStringPropertyNeedsImplementingToo
        {
            get;
            set;
        }

        int ISimpleInterface.ThisIntegerPropertyOnlyNeedsAGetter
        {
            get
            {
                return encapsulatedInteger;
            }
        }

        event EventHandler<EventArgs> ISimpleInterface.InterfacesCanContainEventsToo
        {
            add { encapsulatedEvent += value; }
            remove { encapsulatedEvent -= value; }
        }

        private int encapsulatedInteger;
        private event EventHandler<EventArgs> encapsulatedEvent;
    }
}
