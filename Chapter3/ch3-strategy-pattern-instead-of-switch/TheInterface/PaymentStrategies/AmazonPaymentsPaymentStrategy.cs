using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlinePaymentInterface;

namespace PaymentStrategies
{
    public class AmazonPaymentsPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Amazon payment chosen");
        }
    }
}
