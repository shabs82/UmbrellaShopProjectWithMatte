using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService
{
    public interface ICustomerService
    {

        List<Customer> GetCustomer();
        Customer GetCustomerByID(int id);
        Customer NewCustomer(string firstName, string lastName, string address, string email, string phoneNumber, int id);
        Customer CreateCustomer(Customer customer);
        Customer DeleteCustomer(int id);
        Customer UpdateCustomer(int id, Customer customer);

    }
}
