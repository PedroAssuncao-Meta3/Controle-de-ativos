using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Controle_Ativos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        private readonly IPatrimonioRepositorio _patrimonioRepositorio;
        private readonly IMovimentacaoPatrimonioRepositorio _movimentacaoPatrimonioRepositorio;
        public HomeController(ILogger<HomeController> logger,
                              IColaboradorRepositorio colaboradorRepositorio,
                              IPatrimonioRepositorio patrimonioRepositorio, 
                              IMovimentacaoPatrimonioRepositorio movimentacaoPatrimonioRepositorio)
        {
            _patrimonioRepositorio = patrimonioRepositorio;
            _colaboradorRepositorio = colaboradorRepositorio;
            _movimentacaoPatrimonioRepositorio = movimentacaoPatrimonioRepositorio;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.QtdeFuncionarios = _colaboradorRepositorio.QtdeColaboradores();
            ViewBag.ValorTotalPat = _patrimonioRepositorio.ValorTotal();
            ViewBag.QtdePatrimonios = _patrimonioRepositorio.QtdePatrimonios();
            ViewBag.QtdeEmprestimos = _movimentacaoPatrimonioRepositorio.QtdeEmprestimos();
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
        public IActionResult Template()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}