using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        // foreach (var product in productManager.GetByUnitPrice(50, 100))
        // {
        //     Console.WriteLine(product.ProductName);
        // }
        //
        // foreach (var product in productManager.GetAllByCategoryId(2))
        // {
        //     Console.WriteLine(product.CategoryId + " " + product.ProductName);
        // }
        productManager.Add(new Product{ProductName = "Masa",CategoryId = 2,UnitPrice = 2000,UnitsInStock = 20});
        foreach (var product in productManager.GetAllByCategoryId(2))
        {
            Console.WriteLine(product.CategoryId + " " + product.ProductName);
        }
    }
}