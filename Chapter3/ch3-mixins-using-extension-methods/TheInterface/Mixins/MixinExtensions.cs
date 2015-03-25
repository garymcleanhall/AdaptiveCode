using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mixins
{
    public static class MixinExtensions
    {
        public static void FirstExtensionMethod(this ITargetInterface target)
        {
            Console.WriteLine("The first extension method was called.");
        }

        public static void SecondExtensionMethod(this ITargetInterface target)
        {
            Console.WriteLine("The second extension method was called.");
        }
    }
}
