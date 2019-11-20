using UmbrellaShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.DomainService
{
    public interface IUmbrellaRepository
    {
        IEnumerable<Umbrella> ReadUmbrellas();
        Umbrella Create(Umbrella umbrella);
        Umbrella Delete(int id);
        Umbrella Update(int id, Umbrella umbrella);
        Umbrella ReadByID(int id);
    }
}
