using CleanArchMvc.Data.Context;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Data.Repositories
{
    public class ProductCategory : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;
        public ProductCategory(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategory(int? id)
        {
            //eager loading
            return await _productContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> Remove(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
