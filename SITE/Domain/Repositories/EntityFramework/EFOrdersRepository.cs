using Microsoft.EntityFrameworkCore;
using SITE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain.Repositories.Abstract
{
    public class EFOrdersRepository : IOrdersRepository
    {
        private readonly AppDbContext context;
        public EFOrdersRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> GetOrders()
        {
            return context.Orders;
        }
        public Order GetOrderById(Guid id)
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }
        public void SaveOrder(Order entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteOrder(Guid id)
        {
            context.Orders.Remove(new Order() { Id = id });
            context.SaveChanges();
        }
    }
}
