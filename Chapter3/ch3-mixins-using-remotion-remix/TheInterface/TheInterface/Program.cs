using Mixins;
using Remotion.Mixins;
using Remotion.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = MixinConfiguration.BuildFromActive()
                .ForClass<TargetImplementation>()
                .AddMixin<MixinImplementationA>()
                .AddMixin<MixinImplementationB>()
                .AddMixin<MixinImplementationC>()
                .BuildConfiguration();
            
            MixinConfiguration.SetActiveConfiguration(config);

            var client = new MixinClient(ObjectFactory.Create<TargetImplementation>(ParamList.Empty));
            client.Run();

            Console.ReadKey();
        }
    }
}
