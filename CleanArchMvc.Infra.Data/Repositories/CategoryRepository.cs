using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext context)
        {
            _categoryContext = context;
        }

        public async Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Remove(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
