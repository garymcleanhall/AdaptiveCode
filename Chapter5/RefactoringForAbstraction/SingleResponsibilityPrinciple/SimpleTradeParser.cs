using System.Collections.Generic;

using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeParser : ITradeParser
    {
        private readonly ITradeValidator _tradeValidator;
        private readonly ITradeMapper _tradeMapper;

        public SimpleTradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
        {
            _tradeValidator = tradeValidator;
            _tradeMapper = tradeMapper;
        }

        public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData)
        {
            List<TradeRecord> trades = new List<TradeRecord>();
            foreach (string line in tradeData)
            {
                string[] fields = line.Split(',');

                if (!_tradeValidator.Validate(fields))
                {
                    continue;
                }

                TradeRecord trade = _tradeMapper.Map(fields);

                trades.Add(trade);
            }

            return trades;
        }
    }
}
