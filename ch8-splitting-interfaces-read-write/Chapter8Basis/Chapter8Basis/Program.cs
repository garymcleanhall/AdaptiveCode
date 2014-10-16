using Controllers;
using Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {
            var userSettings = new UserSettingsConfig();

            var writingController = new WritingController(userSettings);
            var readingController = new ReadingController(userSettings);

            var theme = readingController.GetTheme();
            Console.WriteLine("The current theme is: {0}", theme);

            writingController.SetTheme("CustomThemeName");

            theme = readingController.GetTheme();
            Console.WriteLine("The new theme is: {0}", theme);
            Console.ReadKey();
        }
    }
}
