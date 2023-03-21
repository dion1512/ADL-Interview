using ADL.Data.Entities;
using ADL.Repositories.Interfaces;
using ADL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }
    }
}
