using System;
using System.Collections.Generic;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService
{
    public interface IOrderService
    {
        Order NewOrder(int id, DateTime date);
        Order CreateOrder(Order order);
        List<Order> ReadAllOrders();
        List<Order> ReadById(int id);
        Order Update(Order order);
        Order Delete(int id);
        List<Order> GetFilteredOrders(Filter filter);
    }
}