using Crud;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class OrderController
    {
        private readonly IRead<Order> reader;
        private readonly ISave<Order> saver;
        private readonly IDelete<Order> deleter;

        public OrderController(IRead<Order> orderReader, ISave<Order> orderSaver, IDelete<Order> orderDeleter)
        {
            reader = orderReader;
            saver = orderSaver;
            deleter = orderDeleter;
        }

        public void CreateOrder(Order order)
        {
            saver.Save(order);
        }

        public Order GetSingleOrder(Guid identity)
        {
            return reader.ReadOne(identity);
        }

        public void UpdateOrder(Order order)
        {
            saver.Save(order);
        }

        public void DeleteOrder(Order order)
        {
            deleter.Delete(order);
        }
    }
}
