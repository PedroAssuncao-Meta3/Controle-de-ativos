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
    public class ColaboradorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepositorio _repositorio;

        public ColaboradorController(IMapper mapper, IColaboradorRepositorio repositorio)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<ColaboradorViewModel>>(_repositorio.ObterTodos());
            return View(registros);
        }

        // GET: Colaborador/Details/5
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

            return View(_mapper.Map<ColaboradorViewModel>(tabela));
        }

        // GET: Colaborador/Create
        public IActionResult Create()
        {
            var registro = new ColaboradorViewModel();
            registro.Clientes = _mapper.Map<List<ClienteViewModel>>(_repositorio.RecuperaListaCliente());
            return View(registro);
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ColaboradorViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Colaborador>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: Colaborador/Edit/5
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

            return View(_mapper.Map<ColaboradorViewModel>(tabela));
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ColaboradorViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<Colaborador>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorExists(tabela.Id))
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

        // GET: Colaborador/Delete/5
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

            return View(_mapper.Map<ColaboradorViewModel>(tabela));
        }

        // POST: Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradorExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
