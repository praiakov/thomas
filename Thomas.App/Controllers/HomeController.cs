using KissLog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Thomas.App.ViewModels;
using Thomas.Business.Interfaces;
using Thomas.Business.Models;

namespace Thomas.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        private readonly IChamadoRepository _chamadoRepository;

        public HomeController(ILogger logger, IChamadoRepository chamadoRepository)
        {
            _logger = logger;
            _chamadoRepository = chamadoRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public JsonResult ReportChamados()
        {

            var query = _chamadoRepository.ObterTodos().Result
                .Where(x => x.DataAbertura.Year == DateTime.Now.Year);

            if (!query.Any())
                return Json(new Dashboard());

            var mesMin = query.Min(x => x.DataAbertura.Month);

            var mesCount = query.Select(x => x.DataAbertura.Month)
                .GroupBy(x => x)
                .Count();

            var mesesIntervalo = GetMeses(mesMin, mesCount);

            var chamadosAberto = GetChamadosAberto(mesesIntervalo);
            var chamadosFechado = GetChamadosFechado(mesesIntervalo);
            var chamadosPausado = GetChamadosPausado(mesesIntervalo);
            var chamadosCancelado = GetChamadosCancelado(mesesIntervalo);

            var meses = GetNomeMeses(mesesIntervalo);

            var jsonObj = new Dashboard()
            {
                Aberto = chamadosAberto.ToArray(),
                AbertoCount = chamadosAberto.Sum(),
                Fechado = chamadosFechado.ToArray(),
                FechadoCount = chamadosFechado.Sum(),
                Pausado = chamadosPausado.ToArray(),
                PausadoCount = chamadosPausado.Sum(),
                Cancelado = chamadosCancelado.ToArray(),
                CanceladoCount = chamadosCancelado.Sum(),
                Mes = meses.ToArray()
            };

            return Json(jsonObj);
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }

        #region Metodos privados
        private List<int> GetMeses(int start, int count)
        {
            return Enumerable.Range(start, count)
                .ToList();
        }

        private List<string> GetNomeMeses(List<int> meses)
        {
            var mesesNames = meses
               .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(x))
               .ToList();

            return mesesNames;
        }

        private List<int> GetChamadosAberto(List<int> meses)
        {
            List<int> aberto = new List<int>();

            var query = _chamadoRepository.ObterTodos().Result;

            foreach (var m in meses.OrderBy(x => x))
            {
                var total = query.Where(x => x.DataAbertura.Month == m && x.TipoStatus == TipoStatus.Aberto).Count();
                aberto.Add(total);
            }

            return aberto;
        }

        private List<int> GetChamadosFechado(List<int> meses)
        {
            List<int> fechado = new List<int>();

            var query = _chamadoRepository.ObterTodos().Result;

            foreach (var m in meses.OrderBy(x => x))
            {
                var total = query.Where(x => x.DataAbertura.Month == m && x.TipoStatus == TipoStatus.Fechado).Count();
                fechado.Add(total);
            }

            return fechado;
        }

        private List<int> GetChamadosPausado(List<int> meses)
        {
            List<int> pausado = new List<int>();

            var query = _chamadoRepository.ObterTodos().Result;

            foreach (var m in meses.OrderBy(x => x))
            {
                var total = query.Where(x => x.DataAbertura.Month == m && x.TipoStatus == TipoStatus.Pausado).Count();
                pausado.Add(total);
            }

            return pausado;
        }

        private List<int> GetChamadosCancelado(List<int> meses)
        {
            List<int> cancelado = new List<int>();

            var query = _chamadoRepository.ObterTodos().Result;

            foreach (var m in meses.OrderBy(x => x))
            {
                var total = query.Where(x => x.DataAbertura.Month == m && x.TipoStatus == TipoStatus.Cancelado).Count();
                cancelado.Add(total);
            }

            return cancelado;
        }
        #endregion
    }
}
