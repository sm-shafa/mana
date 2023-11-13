using ManaCoreWebApplication.Data;

namespace ManaCoreWebApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        public IProductRepository Products { get; set; }
        public ICategoryRepository Categories { get; set; }

        public UnitOfWork(IDbContext dbContext, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = dbContext;
            Products = productRepository;
            Categories = categoryRepository;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}