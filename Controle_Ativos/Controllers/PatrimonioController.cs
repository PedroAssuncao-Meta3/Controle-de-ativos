using AutoMapper;
using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers
{
    public class PatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPatrimonioRepositorio _repositorio;
        private readonly IAtributoXPatrimonioRepositorio _repositorioAtrXPat;
        private readonly IAtributoXTipoPatrimonioRepositorio _repositorioAtrXTP;

        public PatrimonioController(IMapper mapper, IPatrimonioRepositorio repositorio, IAtributoXPatrimonioRepositorio repositorioAtrXPat, IAtributoXTipoPatrimonioRepositorio repositorioAtrXTP)
        {
            _repositorio = repositorio;
            _repositorioAtrXPat = repositorioAtrXPat;
            _repositorioAtrXTP = repositorioAtrXTP;
            _mapper = mapper;
        }

        // GET: Patrimonio
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<PatrimonioViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: Patrimonio/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabela = _repositorio.ObterPorId(id);

            if (tabela == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PatrimonioViewModel>(tabela));
        }

        // GET: Patrimonio/Create
        public IActionResult Create()
        {
            var registro = new PatrimonioViewModel();
            registro.TipoPatrimonios = _mapper.Map<List<TipoPatrimonioViewModel>>(_repositorio.RecuperaListaTipoPatrimonio());
            return View(registro);
        }

        // POST: Patrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatrimonioViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Patrimonio>(registro);
                _repositorio.Adicionar(tabela);

                var atributos = _repositorioAtrXTP.RecupeaListaAtributoDoTipoPatrimonio(tabela.TipoPatrimonioId);

                var listaAtributosxPat = new List<AtributoXPatrimonioViewModel>();
                atributos.ForEach(x => listaAtributosxPat.Add(new AtributoXPatrimonioViewModel() { AtributoId = x.AtributoId}));
                listaAtributosxPat.ForEach(x => x.PatrimonioId = tabela.Id);
                listaAtributosxPat.ForEach(x => x.Conteudo = "Insira um conteúdo");

                _repositorioAtrXPat.AdicionarLista(_mapper.Map<List<AtributoXPatrimonio>>(listaAtributosxPat));

                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Patrimonio/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabela = _repositorio.ObterPorId(id);
           
            if (tabela == null)
            {
                return NotFound();
            }
            

            return View(_mapper.Map<PatrimonioViewModel>(tabela));
        }

        // POST: Patrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PatrimonioViewModel registro)
        {
            
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Patrimonio>(registro);
                
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrimonioExists(tabela.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Patrimonio/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabela = _repositorio.ObterPorId(id);

            if (tabela == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<PatrimonioViewModel>(tabela));
        }

        // POST: Patrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PatrimonioExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
