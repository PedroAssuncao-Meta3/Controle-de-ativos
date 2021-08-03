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
    public class AtributoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAtributoRepositorio _repositorio;

        public AtributoController(IMapper mapper, IAtributoRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: Atributo
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<AtributoViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: Atributo/Details/5
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

            return View(_mapper.Map<AtributoViewModel>(tabela));
        }

        // GET: Atributo/Create
        public IActionResult Create()
        {
            var registro = new AtributoViewModel();
            return View(registro);

        }


        // POST: Atributo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtributoViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Atributo>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Atributo/Edit/5
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

            return View(_mapper.Map<AtributoViewModel>(tabela));
        }

        // POST: Atributo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtributoViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Atributo>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtributoExists(tabela.Id))
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

        // GET: Atributo/Delete/5
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

            return View(_mapper.Map<AtributoViewModel>(tabela));
        }

        // POST: Atributo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AtributoExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
