using Entities.Concrete;

namespace Business.Abstract;

public interface IProductService
{
    List<Product> GetAll();
    
}