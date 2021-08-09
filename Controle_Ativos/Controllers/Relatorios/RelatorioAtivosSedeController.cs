using Controle_Ativos.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers.Relatorios
{
    public class RelatorioAtivosSedeController : Controller
    {
        private readonly DBContexto _contexto;

        public RelatorioAtivosSedeController(DBContexto contexto)
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
                             join tm in _contexto.MovimentacoesPatrimonios on p.Id equals tm.PatrimonioId
                             where p.Descricao != tm.Patrimonio.Descricao

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
