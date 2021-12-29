using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    class ProductRepository : IProductRepository
    {
        public async Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
