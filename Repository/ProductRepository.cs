
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

        public IQueryable<ProductDto> GetOne(int id)
        {
            var q = _context.Products.Where(o => o.Id == id).Select(e => new ProductDto {Id = e.Id});
            return q;
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _context.Products.Where(x => x.Name == name);
        }
    }
}