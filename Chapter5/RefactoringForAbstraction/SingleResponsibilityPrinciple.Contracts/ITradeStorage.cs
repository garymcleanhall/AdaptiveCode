using System.Collections.Generic;

namespace SingleResponsibilityPrinciple.Contracts
{
    public interface ITradeStorage
    {
        void Persist(IEnumerable<TradeRecord> trades);
    }
}