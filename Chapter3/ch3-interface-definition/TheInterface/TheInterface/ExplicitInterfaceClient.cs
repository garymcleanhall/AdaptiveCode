using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class ExplicitInterfaceClient
    {
        public ExplicitInterfaceClient(ExplicitInterfaceImplementation implementationReference, ISimpleInterface interfaceReference)
        {
            // Uncommenting this will cause compilation errors.
            //var instancePropertyValue = implementationReference.ThisIntegerPropertyOnlyNeedsAGetter;
            //implementationReference.ThisMethodRequiresImplementation();
            //implementationReference.ThisStringPropertyNeedsImplementingToo = "Hello";
            //implementationReference.InterfacesCanContainEventsToo += EventHandler;

            var interfacePropertyValue = interfaceReference.ThisIntegerPropertyOnlyNeedsAGetter;
            interfaceReference.ThisMethodRequiresImplementation();
            interfaceReference.ThisStringPropertyNeedsImplementingToo = "Hello";
            interfaceReference.InterfacesCanContainEventsToo += EventHandler;
        }

        void EventHandler(object sender, EventArgs e)
        {
            
        }
    }
}
