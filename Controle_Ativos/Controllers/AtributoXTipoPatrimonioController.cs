using AutoMapper;
using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Controle_Ativos.Controllers
{
    public class AtributoXTipoPatrimonioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAtributoXTipoPatrimonioRepositorio _repositorio;
        private readonly IAtributoRepositorio _repositorioAtributo;
        private readonly ITipoPatrimonioRepositorio _repositorioTipoPatrimonio;

        public AtributoXTipoPatrimonioController(IMapper mapper, IAtributoXTipoPatrimonioRepositorio repositorio, IAtributoRepositorio repositorioAtr, ITipoPatrimonioRepositorio repositorioTP)
        {
            _repositorio = repositorio;
            _repositorioAtributo = repositorioAtr;
            _repositorioTipoPatrimonio = repositorioTP;
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
            registro.TipoPatrimonio = new TipoPatrimonioViewModel();
            registro.Atributos.Add(new AtributoViewModel());


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

                //Inserindo tipo de patrimonio
                var tabelaTP = _mapper.Map<TipoPatrimonio>(registro.TipoPatrimonio);
                tabelaTP.Id = Guid.NewGuid();//Gerando ID patrimonio         
                _repositorioTipoPatrimonio.Adicionar(tabelaTP);

                //Recupera a lista de atributos
                var listaAtrib = _mapper.Map<List<Atributo>>(registro.Atributos);
                
                //Atribui o ID e patrimonio para cada atributo
                listaAtrib.ForEach(atrib =>
                {
                    atrib.Id = Guid.NewGuid();
                    atrib.AtributoXTipoPatrimonios = new List<AtributoXTipoPatrimonio>() { new AtributoXTipoPatrimonio() { TipoPatrimonioId = tabelaTP.Id } };
                });

                foreach (var item in listaAtrib)
                {
                    var listaAtrxPat = new List<AtributoXTipoPatrimonio>();
                    var atrXPat = new AtributoXTipoPatrimonio();
                    atrXPat.TipoPatrimonioId = tabelaTP.Id;
                    listaAtrxPat.Add(atrXPat);
                    item.Id = Guid.NewGuid();
                    item.AtributoXTipoPatrimonios = listaAtrxPat;
                }
                
                //Persiste a lista de atributos
                _repositorioAtributo.AdicionarLista(listaAtrib);

                //var registroTP = new TipoPatrimonioViewModel();
                //AtributoViewModel[] RegistroAtr = new AtributoViewModel[registro.Atributos.Count];
                //registro.Atributos.CopyTo(RegistroAtr);
                //registro.Atributos.Clear();

                //registroTP = registro.TipoPatrimonio;

                //for (int i = 0; i < RegistroAtr.Length; i++)
                //{
                //    var tabelaAtr = _mapper.Map<Atributo>(RegistroAtr[i]);
                //    _repositorioAtributo.Adicionar(tabelaAtr);
                //}

                //registro.TipoPatrimonios = _mapper.Map<List<TipoPatrimonioViewModel>>(_repositorio.RecuperaListaTipoPatrimonio());
                //var registroAux = _mapper.Map<List<AtributoViewModel>>(_repositorio.RecuperaListaAtributo());

                //for (int i = 0; i < registroAux.Count; i++)
                //{

                //    var aux = registroAux.Where(x => x.Descricao == RegistroAtr[i].Descricao).First<AtributoViewModel>();
                //    registro.Atributos.Add(aux);
                //    registro.AtributoId = aux.Id;
                //    registro.TipoPatrimonio = registro.TipoPatrimonios.Where(x => x.Id == tabelaTP.Id).First();
                //    var tabela = _mapper.Map<AtributoXTipoPatrimonio>(registro);
                //    _repositorio.Adicionar(tabela);

                //}

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
