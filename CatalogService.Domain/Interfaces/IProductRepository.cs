using CatalogService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByIds(int[] ids);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        int SaveChanges();
    }
}
