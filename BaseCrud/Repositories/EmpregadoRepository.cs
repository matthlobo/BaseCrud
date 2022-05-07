using BaseCrud.Data.Interfaces;
using BaseCrud.Models;
using BaseCrud.Repositories.Interfaces;

namespace BaseCrud.Repositories
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        private readonly IAppDbContext _context;

        public EmpregadoRepository(IAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Empregado> GetAll()
        {
            return _context.Empregados.ToList();
        }

        public Empregado GetById(int? id)
        {
            return _context.Empregados.Find(id);
        }

        public void Add(Empregado empregado)
        {
            _context.Empregados.Add(empregado);
            _context.SaveChanges();
        }

        public void Edit(Empregado source)
        {
            var empregado = GetById(source.Id);

            if (empregado == null)
                throw new ArgumentException($"O Id do Empregado {empregado.Id} não foi encontrado");

            empregado.Nome = source.Nome;
            empregado.Designacao = source.Designacao;
            empregado.Endereco = source.Endereco;
            empregado.EmpregadoEm = source.EmpregadoEm;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
