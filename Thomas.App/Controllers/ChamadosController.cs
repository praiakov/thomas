using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Thomas.App.ViewModels;
using Thomas.Business.Interfaces;
using Thomas.Business.Models;

namespace Thomas.App.Controllers
{
    public class ChamadosController : BaseController
    {

        private readonly IChamadoRepository _chamadoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        private readonly IChamadoService _chamadoService;

        public ChamadosController(IChamadoRepository chamadoRepository,
            IFornecedorRepository fornecedorRepository,
            IMapper mapper,
            INotificador notificador,
            IChamadoService chamadoService
            ) : base(notificador)
        {
            _chamadoService = chamadoService;
            _chamadoRepository = chamadoRepository;
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ChamadoViewModel>>(await _chamadoRepository.ObterChamadosFornecedores()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var chamadoViewModel = _mapper.Map<ChamadoViewModel>(await _chamadoRepository.ObterPorId(id));

            return View(chamadoViewModel);
        }

        public async Task<IActionResult> Create()
        {

            var chamadoViewModel = await PopularFornecedores(new ChamadoViewModel());

            return View(chamadoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChamadoViewModel chamadoViewModel)
        {
            if (!ModelState.IsValid) return View(chamadoViewModel);

            await _chamadoService.Adicionar(_mapper.Map<Chamado>(chamadoViewModel));

            if (!OperacaoValida()) return View(chamadoViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var chamadoViewModel = await ObterChamado(id);

            if (chamadoViewModel == null)
            {
                return NotFound();
            }

            return View(chamadoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  ChamadoViewModel chamadoViewModel)
        {
            if (id != chamadoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(chamadoViewModel);

            await _chamadoService.Atualizar(_mapper.Map<Chamado>(chamadoViewModel));

            if (!OperacaoValida()) return View(chamadoViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var chamadoViewModel = _mapper.Map<ChamadoViewModel>(await _chamadoRepository.ObterPorId(id));

            if (chamadoViewModel == null)
            {
                return NotFound();
            }

            return View(chamadoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var chamadoViewModel = _mapper.Map<ChamadoViewModel>(await _chamadoRepository.ObterPorId(id));

            if (chamadoViewModel == null) return NotFound();

            await _chamadoRepository.Remover(id);

            return RedirectToAction("Index");
        }

        private async Task<ChamadoViewModel> ObterChamado(Guid id)
        {
            var chamado = _mapper.Map<ChamadoViewModel>(await _chamadoRepository.ObterChamadoFornecedor(id));

            chamado.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());

            return chamado;

        }

        private async Task<ChamadoViewModel> PopularFornecedores(ChamadoViewModel chamado)
        {
            chamado.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return chamado;
        }
    }
}
