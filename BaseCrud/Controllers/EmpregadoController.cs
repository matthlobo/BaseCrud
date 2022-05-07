using BaseCrud.Data;
using BaseCrud.Models;
using BaseCrud.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaseCrud.Controllers
{
    public class EmpregadoController : Controller
    {
        private readonly IEmpregadoService _service;
        public EmpregadoController(IEmpregadoService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var listaDeEmpregados = _service.GetAll();
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
                _service.Add(empregado);
                TempData["ResultOk"] = "Empregado Registrado com Sucesso!";
                return RedirectToAction("Index");
            }
            
            return View(empregado);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var empregadoEncontrado = _service.GetById(id);

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
                _service.Edit(empregado);
                TempData["ResultOk"] = "Empregado editado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(empregado);
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var empregadoEncontrado = _service.GetById(id);

            if (empregadoEncontrado == null)
            {
                return NotFound();
            }
            return View(empregadoEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(int id)
        {
            var deletarEmpregado = _service.GetById(id);
            if (deletarEmpregado == null)
            {
                return NotFound();
            }
            _service.Delete(id);
            TempData["ResultOk"] = "Empregado removido com sucesso!";
            return RedirectToAction("Index");
        }
    }
}