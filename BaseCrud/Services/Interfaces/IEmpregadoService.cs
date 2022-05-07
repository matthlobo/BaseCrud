using BaseCrud.Models;

namespace BaseCrud.Services.Interfaces
{
    public interface IEmpregadoService
    {
        Empregado GetById(int id);
        IEnumerable<Empregado> GetAll();
        Empregado Add(Empregado request);
        Empregado Edit(Empregado request);
        void Delete(int id);
    }
}
