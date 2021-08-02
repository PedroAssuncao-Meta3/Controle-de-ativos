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
    public class TipoPatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoPatrimonioRepositorio _repositorio;

        public TipoPatrimonioController(IMapper mapper, ITipoPatrimonioRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: TipoPatrimonio
        public async Task<IActionResult> Index()
        {
            return View((_repositorio.ObterTodos()));
        }

        // GET: TipoPatrimonio/Details/5
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

            return View(_mapper.Map<TipoPatrimonioViewModel>(tabela));
        }

        // GET: TipoPatrimonio/Create
        public IActionResult Create()
        {
            var registro = new TipoPatrimonioViewModel();
            return View(registro);
        }

        // POST: TipoPatrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoPatrimonioViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<TipoPatrimonio>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: TipoPatrimonio/Edit/5
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

            return View(_mapper.Map<TipoPatrimonioViewModel>(tabela));
        }

        // POST: TipoPatrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TipoPatrimonioViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<TipoPatrimonio>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPatrimonioExists(tabela.Id))
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

        // GET: TipoPatrimonio/Delete/5
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

            return View(_mapper.Map<TipoPatrimonioViewModel>(tabela));
        }

        // POST: TipoPatrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPatrimonioExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
