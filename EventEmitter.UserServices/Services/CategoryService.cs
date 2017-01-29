using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventEmitter.Storage.Repositories;
using EventEmitter.UserServices.Models;

namespace EventEmitter.UserServices.Services
{
    public class CategoryService : ICategoryService
    {
        protected readonly ICategoryRepository CategoryRepository;
        protected readonly IMapper Mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            CategoryRepository = categoryRepository;
            Mapper = mapper;
        }

        public IEnumerable<Category> GetAll()
        {
            var storedData = CategoryRepository.GetAll();
            return storedData.Select(category => Mapper.Map<Storage.POCO.Category, Category>(category));
        }
    }
}