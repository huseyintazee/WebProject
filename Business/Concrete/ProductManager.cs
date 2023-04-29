using Business.Abstract;
using Core.Utilities.Results;
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

    public Product GetById(int productId)
    {
        return _productDal.Get(p => p.ProductId == productId);
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new Result(true, "Ürün Eklendi.");
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new Result(true, "Ürün Silindi.");
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new Result(true, "Ürün Güncellendi.");
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        return _productDal.GetProductDetails();
    }
}