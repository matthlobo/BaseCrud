using BaseCrud.Data.Interfaces;
using BaseCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace BaseCrud.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Empregado> Empregados { get; set; }
    }
}
