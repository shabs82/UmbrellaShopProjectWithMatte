using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Infrastructure.SQLData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UmbrellaShopContext _context;


        public UserRepository(UmbrellaShopContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadAll()
        {
            return _context.User;
        }

        public User ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
