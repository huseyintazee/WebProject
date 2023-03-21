using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal
{
    private List<Product> _products;

    public InMemoryProductDal()
    {
        _products = new List<Product>
        {
            new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitInStocks = 15},
            new Product {ProductId = 2, CategoryId = 2, ProductName = "Kamere", UnitPrice = 2000, UnitInStocks = 5},
            new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 7000, UnitInStocks = 3},
            new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 300, UnitInStocks = 100},
            new Product {ProductId = 5, CategoryId = 2, ProductName = "Mouse", UnitPrice = 200, UnitInStocks = 100},
        };
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Update(Product product)
    {
        Product productToUpdate = _products.SingleOrDefault(s => s.ProductId == product.ProductId);
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitInStocks = product.UnitInStocks;
    }

    public void Delete(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(s => s.ProductId == product.ProductId);
        _products.Remove(productToDelete);
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(s => s.CategoryId == categoryId).ToList();
    }
}