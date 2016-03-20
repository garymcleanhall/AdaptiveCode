
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeMapper : ITradeMapper
    {
        public TradeRecord Map(string[] fields)
        {
            string sourceCurrencyCode = fields[0].Substring(0, 3);
            string destinationCurrencyCode = fields[0].Substring(3, 3);
            int tradeAmount = int.Parse(fields[1]);
            decimal tradePrice = decimal.Parse(fields[2]);

            TradeRecord trade = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / _lotSize,
                Price = tradePrice
            };

            return trade;
        }

        private static float _lotSize = 100000f;
    }
}
