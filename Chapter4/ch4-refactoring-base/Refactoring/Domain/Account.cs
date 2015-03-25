using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Account
    {
        public Account(AccountType type)
        {
            this.type = type;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public int RewardPoints
        {
            get;
            private set;
        }

        public void AddTransaction(decimal amount)
        {
            RewardPoints += CalculateRewardPoints(amount);
            Balance += amount;
        }

        public int CalculateRewardPoints(decimal amount)
        {
            int points;
            switch(type)
            {
                case AccountType.Silver:
                    points = (int)decimal.Floor(amount / 10);
                    break;
                case AccountType.Gold:
                    points = (int)decimal.Floor((Balance / 10000 * 5) + (amount / 5));
                    break;
                case AccountType.Platinum:
                    points = (int)decimal.Ceiling((Balance / 10000 * 10) + (amount / 2));
                    break;
                default:
                    points = 1;
                    break;
            }
            return Math.Max(points, 0);
        }

        private readonly AccountType type;
    }
}
