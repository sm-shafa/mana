
namespace ManaCoreWebApplication.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        int Complete();
    }
}