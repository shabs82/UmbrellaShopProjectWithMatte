using UmbrellaShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Remotion.Linq.Clauses;
using UmbrellaShop.Core.ApplicationService;

namespace UmbrellaShop.Infrastructure.SQLData
{
    public class DbInitializer
    {
        private static object _authenticationHelper;

        public static void Seed(UmbrellaShopContext context)
        {
            var listOfUmbrellas = new List<Umbrella>();
            var listOfCustomer = new List<Customer>();
            var listofOrders = new List<Order>();
            var listofUser = new List<User>();

            string password = "1234";
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashAdmin, out byte[] passwordSaltAdmin);
            _authenticationHelper.CreatePasswordHash(password, out byte[] passwordHashUser, out byte[] passwordSaltUser);

           var User1 = new User{ Username = "Admin", Password = "passwordHashAdmin", IsAdmin = true };
           var User2 = new User{ Username = "User", Password = "passwordHashUser", IsAdmin = false };
           listofUser.Add(User1);
           listofUser.Add(User2);

            var Customer1 = new Customer { FirstName = "Dude", LastName = "Son", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer2 = new Customer { FirstName = "Big", LastName = "Lebowski", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer3 = new Customer { FirstName = "John", LastName = "Rambo", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            var Customer4 = new Customer { FirstName = "Vincent", LastName = "Vega", Address = "Dirty Street", Email = "dude.son@xD.com", PhoneNumber = "66 66 66 66" };
            listOfCustomer.Add(Customer1);
            listOfCustomer.Add(Customer2);
            listOfCustomer.Add(Customer3);
            listOfCustomer.Add(Customer4);
            var Umbrella1 = new Umbrella { Brand = "Callaway", Color = "Brown", Size = 1, Price = 69, Type = "Straight" };
            var Umbrella2 = new Umbrella { Brand = "Wilson",  Color = "Black", Size = 2, Price = 98, Type = "Folding" };
            var Umbrella3 = new Umbrella { Brand = "Dunlop",  Color = "White", Size = 3, Price = 102, Type = "Artistic" };
            var Umbrella4 = new Umbrella { Brand = "MarryPoppins", Color = "Brown", Size = 1, Price = 39, Type = "Artistic" };
            var Umbrella5 = new Umbrella { Brand = "Dunlop",  Color = "Black", Size = 2, Price = 106, Type = "Straight" };
            var Umbrella6 = new Umbrella { Brand = "Wilson", Color = "White", Size = 3, Price = 78, Type = "Folding" };
            listOfUmbrellas.Add(Umbrella1);
            listOfUmbrellas.Add(Umbrella2);
            listOfUmbrellas.Add(Umbrella3);
            listOfUmbrellas.Add(Umbrella4);
            listOfUmbrellas.Add(Umbrella5);
            listOfUmbrellas.Add(Umbrella6);
            var Order1 = new Order {OrderDate = DateTime.Now};
            var Order2 = new Order {OrderDate = DateTime.Now};
            var Order3 = new Order {OrderDate = DateTime.Now};
            listofOrders.Add(Order1);
            listofOrders.Add(Order2);
            listofOrders.Add(Order3);
            


            context.Umbrellas.AddRange(listOfUmbrellas);
            context.Customers.AddRange(listOfCustomer);
            context.Orders.AddRange(listofOrders);
            context.Users.AddRange(listofUser);
            context.SaveChanges();
        }
    }
}