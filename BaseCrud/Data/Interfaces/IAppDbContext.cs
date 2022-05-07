using BaseCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseCrud.Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Empregado> Empregados { get; set; }
        int SaveChanges();
    }
}
