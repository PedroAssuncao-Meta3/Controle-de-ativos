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
    public class AtributoXPatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAtributoXPatrimonioRepositorio _repositorio;

        public AtributoXPatrimonioController(IMapper mapper, IAtributoXPatrimonioRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: AtributoXPatrimonio
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<AtributoXPatrimonioViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: AtributoXPatrimonio/Details/5
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

            return View(_mapper.Map<AtributoXPatrimonioViewModel>(tabela));
        }

        // GET: AtributoXPatrimonio/Create
        public IActionResult Create()
        {
            var registro = new AtributoXPatrimonioViewModel();
            registro.Patrimonios = _mapper.Map<List<PatrimonioViewModel>>(_repositorio.RecuperaListaPatrimonio());
            registro.Atributos = _mapper.Map<List<AtributoViewModel>>(_repositorio.RecuperaListaAtributo());
            return View(registro);

        }


        // POST: AtributoXPatrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtributoXPatrimonioViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<AtributoXPatrimonio>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: AtributoXPatrimonio/Edit/5
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

            return View(_mapper.Map<AtributoXPatrimonioViewModel>(tabela));
        }

        // POST: AtributoXPatrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AtributoXPatrimonioViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                var aux = _mapper.Map<AtributoXPatrimonioViewModel>(_repositorio.ObterPorId(id));
                registro.PatrimonioId = aux.Patrimonio.Id;
                registro.AtributoId = aux.Atributo.Id;
                var tabela = _mapper.Map<AtributoXPatrimonio>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtributoXPatrimonioExists(tabela.Id))
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

        // GET: AtributoXPatrimonio/Delete/5
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

            return View(_mapper.Map<AtributoXPatrimonioViewModel>(tabela));
        }

        // POST: AtributoXPatrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AtributoXPatrimonioExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
