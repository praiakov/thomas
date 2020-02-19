using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Thomas.App.ViewModels;

namespace Thomas.App.Controllers
{
    public class ChamadosController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChamadoViewModel chamadoViewModel)
        {
            if (!ModelState.IsValid) return View(chamadoViewModel);

            return View(chamadoViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,FornecedorId,Titulo,Descricao,DataAbertura,DataFechamento,TipoStatus")] ChamadoViewModel chamadoViewModel)
        {
            
            return View(chamadoViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
