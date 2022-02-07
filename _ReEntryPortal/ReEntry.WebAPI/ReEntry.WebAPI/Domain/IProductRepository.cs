using ReEntry.WebAPI.Models;

namespace ReEntry.WebAPI.Domain
{
    public interface IProductRepository
    {
        void Add(Product product);

        Product WithCode(string code);

        List<Product> All();
    }
}