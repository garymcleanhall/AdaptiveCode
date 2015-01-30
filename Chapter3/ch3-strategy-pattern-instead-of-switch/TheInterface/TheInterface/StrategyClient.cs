using StrategyPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    public class StrategyClient
    {
        public StrategyClient(OnlineCart cart)
        {
            this.cart = cart;
        }

        public void Run()
        {
            cart.CheckOut(PaymentType.GoogleCheckout);
            cart.CheckOut(PaymentType.CreditCard);
            cart.CheckOut(PaymentType.AmazonPayments);
            cart.CheckOut(PaymentType.Paypal);
        }

        private readonly OnlineCart cart;
    }
}
