using System.Collections.Generic;
using MyMusaca.Models;

namespace MyMusaca.Services
{
    public interface IOrdersService
    {
        Order GetActiveOrder(string userId);

        bool AddProductToActiveOrder(string productName, string userId);

        bool CompleteOrder(Order order);

        Order CreateNewOrder(string userId);

        IEnumerable<Order> GetAllCompletedUserOrders(string userId);
    }
}