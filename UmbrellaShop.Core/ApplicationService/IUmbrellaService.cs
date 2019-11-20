using System;
using System.Collections.Generic;
using System.Text;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService
{
    public interface IUmbrellaService
    {
        List<Umbrella> GetUmbrellas();
        List<Umbrella> GetUmbrellasByType(string type);
        Umbrella NewUmbrella(string type, string brand, string color,int size, double price);
        Umbrella CreateUmbrella(Umbrella umbrella);
        Umbrella DeleteUmbrella(int id);
        Umbrella UpdateUmbrella(int id, Umbrella umbrella);
        List<Umbrella> get5CheapestUmbrellas();
        List<Umbrella> sortUmbrellasByPrice();
        Umbrella getUmbrellaByID(int id);
    }
}
