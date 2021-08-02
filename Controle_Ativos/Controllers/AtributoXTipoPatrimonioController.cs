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
    public class AtributoXTipoPatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAtributoXTipoPatrimonioRepositorio _repositorio;

        public AtributoXTipoPatrimonioController(IMapper mapper, IAtributoXTipoPatrimonioRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: AtributoXTipoPatrimonio
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<AtributoXTipoPatrimonioViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: AtributoXTipoPatrimonio/Details/5
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

            return View(_mapper.Map<AtributoXTipoPatrimonioViewModel>(tabela));
        }

        // GET: AtributoXTipoPatrimonio/Create
        public IActionResult Create()
        {
            var registro = new AtributoXTipoPatrimonioViewModel();
            registro.TipoPatrimonios = _mapper.Map<List<TipoPatrimonioViewModel>>(_repositorio.RecuperaListaTipoPatrimonio());
            registro.Atributos = _mapper.Map<List<AtributoViewModel>>(_repositorio.RecuperaListaAtributo());
            return View(registro);

        }


        // POST: AtributoXTipoPatrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtributoXTipoPatrimonioViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<AtributoXTipoPatrimonio>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: AtributoXTipoPatrimonio/Edit/5
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

            return View(_mapper.Map<AtributoXTipoPatrimonioViewModel>(tabela));
        }

        // POST: AtributoXTipoPatrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtributoXTipoPatrimonioViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<AtributoXTipoPatrimonio>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtributoXTipoPatrimonioExists(tabela.Id))
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

        // GET: AtributoXTipoPatrimonio/Delete/5
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

            return View(_mapper.Map<AtributoXTipoPatrimonioViewModel>(tabela));
        }

        // POST: AtributoXTipoPatrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AtributoXTipoPatrimonioExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
