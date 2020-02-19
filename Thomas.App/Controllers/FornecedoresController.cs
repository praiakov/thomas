using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thomas.App.ViewModels;

namespace Thomas.App.Controllers
{
    public class FornecedoresController : Controller
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
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FornecedorViewModel fornecedorViewModel)
        {
           
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
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
