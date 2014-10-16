using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public static class MoreMixinExtensions
    {
        public static void FurtherExtensionMethodA(this ITargetInterface target, int extraParameter)
        {
            Console.WriteLine("Further extension method A was called with argument {0}", extraParameter);
        }

        public static void FurtherExtensionMethodB(this ITargetInterface target, string stringParameter)
        {
            Console.WriteLine("Further extension method B was called with argument {0}", stringParameter);
        }
    }
}
