using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlinePaymentInterface;

namespace PaymentStrategies
{
    public class PaypalPaymentStrategy : IPaymentStrategy
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Paypal payment chosen");
        }
    }
}
