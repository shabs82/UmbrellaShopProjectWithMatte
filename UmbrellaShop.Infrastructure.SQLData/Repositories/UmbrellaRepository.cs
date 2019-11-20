using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;
using UmbrellaShop.Infrastructure.SQLData;

namespace UmbrellaShop.Infrastructure.SQLData.Repositories
{
    public class UmbrellaRepository : IUmbrellaRepository
    {
        UmbrellaShopContext context;
        public UmbrellaRepository(UmbrellaShopContext ctx) {
           context = ctx;
        }
        public Umbrella Create(Umbrella Umbrella)
        {
           context.Umbrellas.Add(Umbrella);
           context.SaveChanges();
           return Umbrella;
        }

        public Umbrella Delete(int id)
        {
            var Umbrella = ReadByID(id);
            context.Remove(Umbrella);
            return Umbrella;
        }

        public Umbrella ReadByID(int id)
        {
            return context.Umbrellas.Find(id);
        }

        public IEnumerable<Umbrella> ReadUmbrellas()
        {
            return context.Umbrellas.ToList();
        }

        public Umbrella Update(int id, Umbrella Umbrella)
        {
            if (Delete(id) != null) {
                context.Umbrellas.Add(Umbrella);
                return Umbrella;
            }
            return null;
        }
    }
}
