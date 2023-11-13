﻿using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Models;

namespace ManaCoreWebApplication.Repository
{
    public interface IProductRepository : IGenericRepository<Product, int>
    {
        IEnumerable<Product> GetProducts(string name);
        Product? GetOne(int id);
    }
}