namespace SingleResponsibilityPrinciple.Contracts
{
    /// <summary>
    /// Interface for TradeValidator strategy implemenations.
    /// </summary>
    public interface ITradeValidator
    {
        /// <summary>
        /// Validates the specified trade data.
        /// </summary>
        /// <param name="tradeData">The trade data.</param>
        /// <returns></returns>
        bool Validate(string[] tradeData);
    }
}