using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class SilverAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            return Math.Max((int)decimal.Floor(amount / SilverTransactionCostPerPoint), 0);
        }

        private const int SilverTransactionCostPerPoint = 10;
    }
}
