using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext : DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public  int SaveChanges()
           => SaveChanges(acceptAllChangesOnSuccess: true);
        public DbSet<User> Users { get; set; }
    }
}
