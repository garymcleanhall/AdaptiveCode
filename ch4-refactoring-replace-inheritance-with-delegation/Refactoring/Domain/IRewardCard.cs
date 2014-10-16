using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRewardCard
    {
        int RewardPoints
        {
            get;
        }

        void CalculateRewardPoints(decimal transactionAmount, decimal accountBalance);
    }
}
