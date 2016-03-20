using System.Collections.Generic;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class TradeProcessor : ITradeProcessor
    {
        private readonly ITradeDataProvider _tradeDataProvider;
        private readonly ITradeParser _tradeParser;
        private readonly ITradeStorage _tradeStorage;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TradeProcessor" /> class.
        /// </summary>
        /// <param name="tradeDataProvider">The trade data provider.</param>
        /// <param name="tradeParser">The trade parser.</param>
        /// <param name="tradeStorage">The trade storage.</param>
        public TradeProcessor(
            ITradeDataProvider tradeDataProvider,
            ITradeParser tradeParser,
            ITradeStorage tradeStorage)
        {
            _tradeDataProvider = tradeDataProvider;
            _tradeParser = tradeParser;
            _tradeStorage = tradeStorage;
        }

        /// <summary>
        ///     Processes the trades.
        /// </summary>
        public void ProcessTrades()
        {
            IEnumerable<string> lines = _tradeDataProvider.GetTradeData();
            IEnumerable<TradeRecord> trades = _tradeParser.Parse(lines);
            _tradeStorage.Persist(trades);
        }
    }
}