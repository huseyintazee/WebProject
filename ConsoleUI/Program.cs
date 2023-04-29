using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        //Data Transformation Object
        ProductTest();
        //IoC
        //CategoryTest();
    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
            Console.WriteLine(category.CategoryId + " : " + category.CategoryName);
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        var result = productManager.GetProductDetails();
        if (result.IsSuccess)
        {
            foreach (var product in result.Data)
                Console.WriteLine("Ürünün adı : " + product.ProductName + " " + " Kategori adı : " + product.CategoryName);
        }
        else
            Console.WriteLine(result.Message);
    }
}