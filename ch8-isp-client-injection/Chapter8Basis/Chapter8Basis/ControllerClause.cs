using Crud;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8Basis
{
    public class ControllerClause
    {
        public void UnconstrainedService<TService>(TService service)
        {
            service.Equals(null);
            service.GetHashCode();
            service.GetType();
            service.ToString();
        }

        public void ConstrainedService<TService>(TService service)
            where TService : ISave<Order>, IRead<Order>, IDelete<Order>
        {
            service.ReadAll();
            service.ReadOne(Guid.NewGuid());
            var order = new Order();
            service.Save(order);
            service.Delete(order);
        }
    }
}
