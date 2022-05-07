using BaseCrud.Models;

namespace BaseCrud.Repositories.Interfaces
{
    public interface IEmpregadoRepository
    {
        Empregado GetById(int? id);
        IEnumerable<Empregado> GetAll();
        void Add(Empregado empregado);
        void Edit(Empregado empregado);
        void Delete(int id);        
    }
}
