using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    /*
     * Loosely coupled
     * naming convention
     * IoC Container -- Inversion of Control
     */
    private IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public List<Product> Get()
    {
        var result = _productService.GetAll();
        return result.Data;
    }
}