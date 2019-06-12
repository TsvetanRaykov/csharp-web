using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyMusaca.Data;
using MyMusaca.Models;
using MyMusaca.Models.Enums;

namespace MyMusaca.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly MyMusacaDbContext dbContext;

        public OrdersService(MyMusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Order GetActiveOrder(string userId)
        {
            var order = this.dbContext.Orders
                            .Include(o => o.Products)
                            .Include(o => o.Cashier)
                            .Where(o => o.CashierId == userId)
                            .SingleOrDefault(o => o.Status == OrderStatus.Active)
                        ?? this.CreateNewOrder(userId);

            return order;
        }

        public bool CompleteOrder(Order order)
        {
            order.Status = OrderStatus.Completed;
            order.IssuedOn = DateTime.UtcNow;

            this.dbContext.SaveChanges();

            return true;
        }

        public Order CreateNewOrder(string userId)
        {
            var order = new Order
            {
                Id = Guid.NewGuid().ToString(),
                CashierId = userId,
            };

            this.dbContext.Add(order);
            this.dbContext.SaveChanges();

            return order;
        }

        public IEnumerable<Order> GetAllCompletedUserOrders(string userId)
        {
            var orders = this.dbContext.Orders
                .Include(o => o.Products)
                .Include(o => o.Cashier)
                .Where(o =>
                o.Status == OrderStatus.Completed &&
                o.CashierId == userId);

            return orders.ToList();
        }

        public bool AddProductToActiveOrder(string productName, string userId)
        {
            var product = this.dbContext.Products.FirstOrDefault(p => p.Name == productName);
            if (product == null)
            {
                return false;
            }

            var order = this.GetActiveOrder(userId);

            order.Products.Add(product);
            this.dbContext.Update(order);

            this.dbContext.SaveChanges();

            return true;
        }
    }
}