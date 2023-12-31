using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using ProductManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ProductManagement.Manager
{
    public class CategoryManager : ICategoryManager
    {
        public readonly ILogger<CategoryManager> _logger;
        public readonly ICategoryRepository _categoryRepository;
        
        public CategoryManager(ICategoryRepository categoryRepository, ILogger<CategoryManager> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public Task<List<Category>> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
