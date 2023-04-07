using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal
{
    private List<Product> _products;

    public InMemoryProductDal()
    {
        _products = new List<Product>
        {
            new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
            new Product {ProductId = 2, CategoryId = 2, ProductName = "Kamere", UnitPrice = 2000, UnitsInStock = 5},
            new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 7000, UnitsInStock = 3},
            new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 300, UnitsInStock = 100},
            new Product {ProductId = 5, CategoryId = 2, ProductName = "Mouse", UnitPrice = 200, UnitsInStock = 100},
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
        productToUpdate.UnitsInStock = product.UnitsInStock;
    }

    public void Delete(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(s => s.ProductId == product.ProductId);
        _products.Remove(productToDelete);
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(s => s.CategoryId == categoryId).ToList();
    }
}