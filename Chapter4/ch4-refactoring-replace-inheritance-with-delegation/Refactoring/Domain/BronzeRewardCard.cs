using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class BronzeRewardCard : IRewardCard
    {
        public int RewardPoints
        {
            get;
            private set;
        }

        public void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance)
        {
            RewardPoints += Math.Max((int)decimal.Floor(transactionAmount / BronzeTransactionCostPerPoint), 0);
        }

        private const int BronzeTransactionCostPerPoint = 20;
    }
}
