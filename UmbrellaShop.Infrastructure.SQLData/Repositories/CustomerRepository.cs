using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;
using UmbrellaShop.Infrastructure.SQLData;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PetshopApp2019.Infrastructure.SQLData.Repositories
{
    public class CustomerRepository : ICustomerRepository

    {
        UmbrellaShopContext context;
        public CustomerRepository(UmbrellaShopContext ctx) {
            context = ctx;
        }
        public Customer Create(Customer Customer)
        {
            context.Customers.Add(Customer);
            return Customer;
        }

        public Customer Delete(int id)
        {
            var Customer = ReadByID(id);
            context.Remove(Customer);
            return Customer;
        }

        public Customer ReadByID(int id)
        {
            var Customer = context.Customers.Find(id);
            return Customer;
        }

        public IEnumerable<Customer> ReadCustomers()
        {
            return context.Customers.ToList(); 
        }

        public Customer Update(int id, Customer Customer)
        {
            if (Delete(id) != null) {
                Customer.Id = id;
                context.Customers.Add(Customer);
                return Customer;
            }
            return null;
        }
    }
}
