using Microsoft.EntityFrameworkCore;

namespace ManaCoreWebApplication.Data
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        void Dispose();
    }
}