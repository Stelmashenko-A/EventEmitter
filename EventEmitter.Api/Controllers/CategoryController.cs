using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using EventEmitter.Api.Models.Category;
using EventEmitter.UserServices;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Controllers
{
    public class CategoryController : CommonController
    {
        protected readonly ICategoryService CategoryService;

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        // GET: api/Category
        [AllowAnonymous]
        public IEnumerable<CategoryModel> Get()
        {
            var categories = CategoryService.GetAll();
            return categories.Select(Mapper.Map<Category, CategoryModel>);
        }
    }
}
