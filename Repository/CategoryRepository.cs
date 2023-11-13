using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Models;

namespace ManaCoreWebApplication.Repository
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ManaDbContext context) : base(context)
        {
        }

        public IQueryable<CategoryDto> GetOne(int id)
        {
            return _context.Categories.Where(o => o.Id == id).Select(e => new CategoryDto() {Id = e.Id});
        }
    }
}