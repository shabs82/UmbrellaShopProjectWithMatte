using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService.ServiceImplementation
{
    public class UmbrellaService : IUmbrellaService
    {
        IUmbrellaRepository _UmbrellaRepository;
        public UmbrellaService(IUmbrellaRepository UmbrellaRepository) {
            _UmbrellaRepository = UmbrellaRepository;
        }

        public Umbrella CreateUmbrella(Umbrella Umbrella)
        {
            return _UmbrellaRepository.Create(Umbrella);
        }

        public Umbrella DeleteUmbrella(int id)
        {
            return _UmbrellaRepository.Delete(id);
        }

        public Umbrella getUmbrellaByID(int id) {
           return _UmbrellaRepository.ReadByID(id);
        }

        public List<Umbrella> get5CheapestUmbrellas()
        {
            List<Umbrella> cheapestUmbrellas = new List<Umbrella>(); 
            List<Umbrella> UmbrellasByPrice = sortUmbrellasByPrice();
            for (int i = 0; i < 5; i++) {
                cheapestUmbrellas.Add(UmbrellasByPrice[i]);
            }
            return cheapestUmbrellas;
        }

        public List<Umbrella> GetUmbrellas()
        {
           return _UmbrellaRepository.ReadUmbrellas().ToList();
        }
        public List<Umbrella> GetUmbrellasByType(string type) {
            var list = _UmbrellaRepository.ReadUmbrellas();
            var listByType = list.Where(Umbrella => Umbrella.Type.Equals(type));
            return listByType.ToList();
        }

        public Umbrella NewUmbrella(string type, string name, string color, int size, double price)
        {
            var newUmbrella = new Umbrella()
            {
                Size = size,
                Type = type,
                Brand = name,
                Color = color,
                Price = price,
            };
            return newUmbrella;
        }

        public List<Umbrella> sortUmbrellasByPrice()
        {
            var list = GetUmbrellas();
            var sortedList = list.OrderBy(Umbrella => Umbrella.Price).ToList();
            return sortedList;
        }

        public Umbrella UpdateUmbrella(int id, Umbrella Umbrella)
        {
            return _UmbrellaRepository.Update(id, Umbrella);
        }
    }
}
