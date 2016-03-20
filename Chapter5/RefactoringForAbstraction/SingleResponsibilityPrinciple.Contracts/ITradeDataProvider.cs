using System.Collections.Generic;

namespace SingleResponsibilityPrinciple.Contracts
{
    /// <summary>
    /// Interface for TradeDataProvider strategy implemenations.
    /// </summary>
    public interface ITradeDataProvider
    {
        /// <summary>
        /// Gets the trade data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetTradeData();
    }
}