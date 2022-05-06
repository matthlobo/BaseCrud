using BaseCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace BaseCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Adiciona o contexto da tabela
        public DbSet<Empregado> Empregados { get; set; }
    }
}
