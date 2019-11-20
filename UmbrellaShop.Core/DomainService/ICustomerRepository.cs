using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.DomainService
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadCustomers();
        Customer Create(Customer customer);
        Customer Delete(int id);
        Customer Update(int id, Customer customer);
        Customer ReadByID(int id);
    }
}
