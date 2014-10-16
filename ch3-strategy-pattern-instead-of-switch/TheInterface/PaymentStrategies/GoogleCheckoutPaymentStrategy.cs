using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlinePaymentInterface;

namespace PaymentStrategies
{
    public class GoogleCheckoutPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Google payment chosen");
        }
    }
}
