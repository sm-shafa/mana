using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.Repository
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ManaDbContext context) : base(context)
        {
        }

        public Category? GetOne(int id)
        {
            return _context.Categories.AsNoTracking().SingleOrDefault(o => o.Id == id);
        }
    }
}