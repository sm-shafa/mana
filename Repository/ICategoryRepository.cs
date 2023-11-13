using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Models;

namespace ManaCoreWebApplication.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category, int>
    {
        IQueryable<CategoryDto> GetOne(int id);
    }
}