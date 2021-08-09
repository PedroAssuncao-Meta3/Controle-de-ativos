using Controle_Ativos.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers.Relatorios
{
    public class RelatorioPatDesativadosController : Controller
    {
        private readonly DBContexto _contexto;

        public RelatorioPatDesativadosController(DBContexto contexto)
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
                             where p.Ativo == false
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
