using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    List<Product> GetAllByCategoryId(int id);
    List<Product> GetByUnitPrice(decimal min, decimal max);
    Product GetById(int productId);
    IResult Add(Product product);
    IResult Delete(Product product);
    IResult Update(Product product);
    List<ProductDetailDto> GetProductDetails();
}