﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete;

public class ProductManager : IProductService
{
    private IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 1)
            return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IResult Add(Product product)
    {
        var context = new ValidationContext<Product>(product);
        ProductValidator productValidator = new ProductValidator();
        var result = productValidator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult(Messages.ProductDeleted);
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour == 19)
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }
}