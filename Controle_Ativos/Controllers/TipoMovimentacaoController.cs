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
    public class TipoMovimentacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoMovimentacaoRepositorio _repositorio;

        public TipoMovimentacaoController(IMapper mapper, ITipoMovimentacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: TipoMovimentacao
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<TipoMovimentoViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: TipoMovimentacao/Details/5
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

            return View(_mapper.Map<TipoMovimentoViewModel>(tabela));
        }

        // GET: TipoMovimentacao/Create
        public IActionResult Create()
        {
            var registro = new TipoMovimentoViewModel();
            return View(registro);
        }

        // POST: TipoMovimentacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoMovimentoViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<TipoMovimento>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: TipoMovimentacao/Edit/5
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

            return View(_mapper.Map<TipoMovimentoViewModel>(tabela));
        }

        // POST: TipoMovimentacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TipoMovimentoViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<TipoMovimento>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentacaoExists(tabela.Id))
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

        // GET: TipoMovimentacao/Delete/5
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

            return View(_mapper.Map<TipoMovimentoViewModel>(tabela));
        }

        // POST: TipoMovimentacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentacaoExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
