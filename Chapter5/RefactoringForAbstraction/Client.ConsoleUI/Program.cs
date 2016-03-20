using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SingleResponsibilityPrinciple;
using SingleResponsibilityPrinciple.AdoNet;
using SingleResponsibilityPrinciple.Contracts;

namespace Client.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream tradeStream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream("Client.ConsoleUI.trades.txt");

            ILogger logger = new ConsoleLogger();
            ITradeValidator tradeValidator = new SimpleTradeValidator(logger);
            ITradeDataProvider tradeDataProvider = new StreamTradeDataProvider(tradeStream);
            ITradeMapper tradeMapper = new SimpleTradeMapper();
            ITradeParser tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
            ITradeStorage tradeStorage = new AdoNetTradeStorage(logger);

            ITradeProcessor tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
            tradeProcessor.ProcessTrades();

            Console.ReadKey();
        }
    }
}
