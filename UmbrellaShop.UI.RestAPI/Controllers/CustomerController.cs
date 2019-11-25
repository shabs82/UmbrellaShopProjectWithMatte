using System;
using System.Collections;
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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            return Ok(_customerService.CreateCustomer(customer));
        }
        [HttpGet("{id}")]
        public Customer GetCustomerByID(int id)
        {
            return _customerService.GetCustomerByID(id);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomer()
        {
            return Ok(_customerService.GetCustomer());
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            _customerService.UpdateCustomer(id, customer);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}