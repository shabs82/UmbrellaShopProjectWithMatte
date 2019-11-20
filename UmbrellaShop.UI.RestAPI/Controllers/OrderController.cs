using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UmbrellaShop.Core.ApplicationService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> ReadById(int id)
        {
            return _orderService.ReadById(id);
        }

        public ActionResult<IEnumerable<Order>> ReadAll([FromQuery] Filter filter )
        {
            return Ok(_orderService.GetFilteredOrders(filter));
            //return _orderService.ReadAllOrders();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.Delete(id);
        }

        [HttpPut]
        public void UpdateOrder(Order order)
        {
            _orderService.Update(order);
        }

        [HttpPost]
        public void CreateOrder(Order order)
        {
            _orderService.CreateOrder(order);
        }
    }
}