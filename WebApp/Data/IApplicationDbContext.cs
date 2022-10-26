using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public interface IApplicationDbContext 
    {
        public DbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
