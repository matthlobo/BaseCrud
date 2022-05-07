using BaseCrud.Models;
using BaseCrud.Repositories.Interfaces;
using BaseCrud.Services.Interfaces;

namespace BaseCrud.Services
{
    public class EmpregadoService : IEmpregadoService
    {
        private readonly IEmpregadoRepository _empregadoRepository;
        public EmpregadoService(IEmpregadoRepository empregadoRepository)
        {
            _empregadoRepository = empregadoRepository;
        }

        public IEnumerable<Empregado> GetAll()
        {
            var listaDeEmpregados = _empregadoRepository.GetAll();
            return listaDeEmpregados.ToList();
        }

        public Empregado GetById(int id)
        {
            return _empregadoRepository.GetById(id);
        }

        public Empregado Add(Empregado request)
        {
            _empregadoRepository.Add(request);
            return request;
        }

        public Empregado Edit(Empregado request)
        {
            _empregadoRepository.Edit(request);
            return request;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
