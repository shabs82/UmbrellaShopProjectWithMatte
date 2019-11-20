using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService.ServiceImplemetation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;//create a variable petRepo as petService is dependent on pet repository.

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order NewOrder(int id , DateTime date)
        {
            Order order = new Order(){id = id , OrderDate = date};
            return order;
        }
        public Order CreateOrder(Order order)
        {
            return _orderRepository.CreateOrder(order);
        }

        public Order Delete(int id)
        {
           return _orderRepository.Delete(id);
        }

        public List<Order> GetFilteredOrders(Filter filter)
        {
            return _orderRepository.ReadAllOrders(filter).ToList();
        }

        public List<Order> ReadAllOrders()
        {
            return _orderRepository.ReadAllOrders().ToList();
        }

        public List<Order> ReadById(int id)
        {
            return _orderRepository.ReadById(id).ToList();
        }

        public Order Update(Order order)
        {
            return _orderRepository.Update(order);
        }
    }
}
