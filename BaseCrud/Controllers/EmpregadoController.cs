using BaseCrud.Data;
using BaseCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.Controllers
{
    public class EmpregadoController : Controller
    {
        private readonly AppDbContext _context;
        public EmpregadoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Empregado> listaDeEmpregados = _context.Empregados;
            return View(listaDeEmpregados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                _context.Empregados.Add(empregado);
                _context.SaveChanges();
                TempData["ResultOk"] = "Empregado Registrado com Sucesso!";
                return RedirectToAction("Index");
            }
            
            return View(empregado);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empregadoEncontrado = _context.Empregados.Find(id);

            if (empregadoEncontrado == null)
            {
                return NotFound();
            }

            return View(empregadoEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empregado empregado)
        {
            if (ModelState.IsValid)
            {
                _context.Empregados.Update(empregado);
                _context.SaveChanges();
                TempData["ResultOk"] = "Empregado editado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(empregado);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var empregadoEncontrado = _context.Empregados.Find(id);

            if (empregadoEncontrado == null)
            {
                return NotFound();
            }
            return View(empregadoEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int? id)
        {
            var deletarEmpregado = _context.Empregados.Find(id);
            if (deletarEmpregado == null)
            {
                return NotFound();
            }
            _context.Empregados.Remove(deletarEmpregado);
            _context.SaveChanges();
            TempData["ResultOk"] = "Empregado removido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}