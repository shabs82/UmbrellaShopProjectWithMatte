using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.DomainService
{
    public interface IOrderRepository
    {
        
        Order CreateOrder(Order order);
        IEnumerable<Order> ReadAllOrders(Filter filter = null);
        IEnumerable<Order> ReadById(int id);
        Order Update(Order order);
        Order Delete(int id);
    }
}
