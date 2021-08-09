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
    public class MovimentacaoPatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoPatrimonioRepositorio _repositorio;
        private readonly ITipoMovimentacaoRepositorio _repositorioTP;

        public MovimentacaoPatrimonioController(IMapper mapper, IMovimentacaoPatrimonioRepositorio repositorio, ITipoMovimentacaoRepositorio repositorioTP)
        {
            _repositorio = repositorio;
            _repositorioTP = repositorioTP;
            _mapper = mapper;
        }

        // GET: MovimentacaoPatrimonio
        public async Task<IActionResult> Index()
        {
            var registros = _mapper.Map<List<MovimentacaoPatrimonioViewModel>>(_repositorio.ObterTodos());
            registros.ForEach(x => x.TipoMovimentacoes = _mapper.Map<List<TipoMovimentoViewModel>>(_repositorioTP.ObterTodos()));
            return View(registros);
        }

        // GET: MovimentacaoPatrimonio/Details/5
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

            return View(_mapper.Map<MovimentacaoPatrimonioViewModel>(tabela));
        }

        // GET: MovimentacaoPatrimonio/Create
        public IActionResult Create()
        {
            var registro = new MovimentacaoPatrimonioViewModel();
            registro.Colaboradores = _mapper.Map<List<ColaboradorViewModel>>(_repositorio.RecuperaListaColaborador());
            registro.Patrimonios = _mapper.Map<List<PatrimonioViewModel>>(_repositorio.RecuperaListaPatrimonio());
            registro.TipoMovimentacoes = _mapper.Map<List<TipoMovimentoViewModel>>(_repositorio.RecuperaListaTipoMovimentacao());
            return View(registro);

        }


        // POST: MovimentacaoPatrimonio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovimentacaoPatrimonioViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<MovimentacaoPatrimonio>(registro);
                _repositorio.Adicionar(tabela);
                return RedirectToAction(nameof(Index));
            }
            return View(registro);
        }

        // GET: MovimentacaoPatrimonio/Edit/5
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
            var registro = _mapper.Map<MovimentacaoPatrimonioViewModel>(tabela);
            registro.Colaboradores = _mapper.Map<List<ColaboradorViewModel>>(_repositorio.RecuperaListaColaborador());
            registro.Patrimonios = _mapper.Map<List<PatrimonioViewModel>>(_repositorio.RecuperaListaPatrimonio());
            registro.TipoMovimentacoes = _mapper.Map<List<TipoMovimentoViewModel>>(_repositorio.RecuperaListaTipoMovimentacao());
            return View(registro);
        }

        // POST: MovimentacaoPatrimonio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MovimentacaoPatrimonioViewModel registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tabela = _mapper.Map<MovimentacaoPatrimonio>(registro);
                try
                {
                    _repositorio.Atualizar(tabela);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoPatrimonioExists(tabela.Id))
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

        // GET: MovimentacaoPatrimonio/Delete/5
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

            return View(_mapper.Map<MovimentacaoPatrimonioViewModel>(tabela));
        }

        // POST: MovimentacaoPatrimonio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _repositorio.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoPatrimonioExists(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

    }
}
