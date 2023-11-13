
using ManaCoreWebApplication.App.Dto;
using ManaCoreWebApplication.Data;
using ManaCoreWebApplication.Models;

namespace ManaCoreWebApplication.Repository
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(ManaDbContext context) : base(context)
        {
        }

        public Product? GetOne(int id)
        {
            return _context.Products.SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _context.Products.Where(x => x.Name == name);
        }
    }
}