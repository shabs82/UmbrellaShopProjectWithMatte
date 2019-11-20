using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.DomainService
{
    public interface IUserRepository
    { 
            User Create(User user);
            User Update(User user);
            User Delete(int id);
            User ReadById(int id);
            IEnumerable<User> ReadAll();
        }
    }

