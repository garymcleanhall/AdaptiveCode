using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OnlinePaymentInterface;
using PaymentStrategies;

namespace StrategyPattern
{
    public class OnlineCart
    {
        public OnlineCart()
        {
            paymentStrategies = new Dictionary<PaymentType, IPaymentStrategy>();
            paymentStrategies.Add(PaymentType.CreditCard, new PaypalPaymentStrategy());
            paymentStrategies.Add(PaymentType.GoogleCheckout, new GoogleCheckoutPaymentStrategy());
            paymentStrategies.Add(PaymentType.AmazonPayments, new AmazonPaymentsPaymentStrategy());
            paymentStrategies.Add(PaymentType.Paypal, new PaypalPaymentStrategy());
        }

        public void CheckOut(PaymentType paymentType)
        {
            paymentStrategies[paymentType].ProcessPayment();
        }

        private IDictionary<PaymentType, IPaymentStrategy> paymentStrategies;
    }
}
