namespace SingleResponsibilityPrinciple.Contracts
{
    public interface ITradeValidator
    {
        bool Validate(string[] tradeData);
    }
}