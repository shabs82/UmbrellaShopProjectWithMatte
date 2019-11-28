namespace UmbrellaShop.Infrastructure.SQLData
{
    public interface IDbInitializer
    {
        void Seed(UmbrellaShopContext context);
    }
}