using Controle_Ativos.Data.Contexto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers.Relatorios
{
    public class RelatorioTipoPatXAtributoController : Controller
    {
        private readonly DBContexto _contexto;

        public RelatorioTipoPatXAtributoController(DBContexto contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var registros = (from tp in _contexto.TiposPatrimonio
                             join tpxat in _contexto.AtributosXTiposPatrimonio on tp.Id equals tpxat.TipoPatrimonioId
                             join at in _contexto.Atributos on tpxat.AtributoId equals at.Id
                             select new
                             {
                                 TipoPatrimonio = tp.Descricao,
                                 Atributo = at.Descricao
                             }).ToList().OrderBy(c => c.TipoPatrimonio);

            return Json(registros);
        }

    }
}
