using Controle_Ativos.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers.Relatorios
{
    public class RelatorioContadorController : Controller
    {
        private readonly DBContexto _contexto;

        public RelatorioContadorController(DBContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var registros = (from p in _contexto.Patrimonios
                             where p.Ativo == true
                             select new
                             {
                                 Patrimonio = p.NumeroPatrimonio,
                                 PatrimonioDescricao = p.Descricao,
                             }
                             ).ToList();

            return Json(registros);
        }

    }
}
