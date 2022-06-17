using Microsoft.EntityFrameworkCore;
using SITE.Domain.Entities;
using SITE.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SITE.Domain.Repositories.EntityFramework
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public EFOrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> GetOrder()
        {
            return context.Order;
        }
        public Order GetOrderById(Guid id)
        {
            return context.Order.FirstOrDefault(x => x.Id == id);
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
            context.Order.Remove(new Order() { Id = id });
            context.SaveChanges();
        }
    }
}
