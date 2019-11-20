using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService
{
    public interface IUserService
    {

        User Create(User user);
        User Update(User user);
        User Delete(int id);
        User ReadById(int id);
        User ValidateUser(LoginInputModel loginInputModel);
    }
}
