using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SingleResponsibilityPrinciple.trades.txt");

            var tradeProcessor = new TradeProcessor();
            tradeProcessor.ProcessTrades(tradeStream);

            Console.ReadKey();
        }
    }
}
