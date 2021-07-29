using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers
{
    public class AtributoXTipoPatrimonioController : Controller
    {
        private readonly IAtributoXTipoPatrimonioRepositorio _repositorio;

        public AtributoXTipoPatrimonioController(IAtributoXTipoPatrimonioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: AtributoXTipoPatrimonio
        public async Task<IActionResult> Index()
        {
            return View(_repositorio.ObterTodos());
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

            return View(tabela);
        }

        // GET: AtributoXTipoPatrimonio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AtributoXTipoPatrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtributoXTipoPatrimonio tabela)
        {
            if (ModelState.IsValid)
            {
                tabela.Id = Guid.NewGuid();
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(tabela);
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
            return View(tabela);
        }

        // POST: AtributoXTipoPatrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtributoXTipoPatrimonio tabela)
        {
            if (id != tabela.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            return View(tabela);
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

            return View(tabela);
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
