using UnitTest.MVC.Models;
using UnitTest.MVC.Models.Entities;

namespace UnitTest.MVC.Services;

public class ProductService : IProductService
{

    private readonly DataBaseContext _context;
    public ProductService(DataBaseContext context)
    {
        _context = context;
    }
    public Product Add(Product product)
    {

        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product GetById(long id)
    {
        return _context.Products.Find(id);
    }

    public void Remove(long id)
    {
        var product = _context.Products.Find(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}
