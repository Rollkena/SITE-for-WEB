using SITE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain.Repositories.Abstract
{
    public interface IOrdersRepository
    {
        IQueryable<Order> GetOrders();
        Order GetOrderById(Guid id);
        void SaveOrder(Order entity);
        void DeleteOrder(Guid id);
    }
}
