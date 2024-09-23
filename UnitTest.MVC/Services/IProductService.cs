using UnitTest.MVC.Models.Entities;

namespace UnitTest.MVC.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product Add(Product product);
    Product GetById(long id);
    void Remove(long id);
}
