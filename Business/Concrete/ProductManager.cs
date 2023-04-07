using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll();
    }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(p => p.CategoryId == id);
    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
    }

    public void Add(Product product)
    {
        _productDal.Add(product);
        Console.WriteLine("Ürün eklendi" + product.ProductName);
    }

    public void Delete(Product product)
    {
        _productDal.Delete(product);
        Console.WriteLine("Ürün silindi" + product.ProductName);
    }

    public void Update(Product product)
    {
        _productDal.Update(product);
        Console.WriteLine("Ürün güncellendi" + product.ProductName);
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        return _productDal.GetProductDetails();
    }
}