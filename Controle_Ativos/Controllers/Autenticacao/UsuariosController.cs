using AutoMapper;
using Controle_Ativos.BLL.Interfaces.Servicos.Login;
using Controle_Ativos.BLL.Models.Login;
using Controle_Ativos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Controle_Ativos.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServico _UsuarioServico;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioServico UsuarioServico,
                                  IMapper mapper)
        {
            _UsuarioServico = UsuarioServico;
            _mapper = mapper;
        }

        // GET: PadraoReconhecimentoes
        public IActionResult Index()
        {
            var usuario = _UsuarioServico.ObterTodos();
            var usuarioVM = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);

            return View(usuarioVM);
        }

        // GET: PadraoReconhecimentoes/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Usuario = _UsuarioServico.ObterPorId(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            var usuarioVM = _mapper.Map<UsuarioViewModel>(Usuario);
            return View(usuarioVM);
        }

        // GET: PadraoReconhecimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadraoReconhecimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel usuarioVM)
        {
            var usuario = _mapper.Map<Usuario>(usuarioVM);

            ValidaLoginUsuario(usuario);

            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                _UsuarioServico.Adicionar(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioVM);
        }

        private void ValidaLoginUsuario(Usuario Usuario)
        {
            if (ValidaUsuario(Usuario))
            {
                ModelState.AddModelError("Login", "Login já existe no banco de dados");
            }
        }

        // GET: PadraoReconhecimentoes/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Usuario = _UsuarioServico.ObterPorId(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            var usuarioVM = _mapper.Map<UsuarioViewModel>(Usuario);
            return View(usuarioVM);
        }

        // POST: PadraoReconhecimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, UsuarioViewModel usuarioVM)
        {
            var usuario = _mapper.Map<Usuario>(usuarioVM);
            if (id != usuario.Id)
            {
                return NotFound();
            }

            ValidaLoginUsuario(usuario);

            if (ModelState.IsValid)
            {
                try
                {
                    _UsuarioServico.Atualizar(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_UsuarioServico.ExisteRegistro(usuario.Id))
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
            return View(usuarioVM);
        }

        // GET: PadraoReconhecimentoes/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Usuario = _UsuarioServico.ObterPorId(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            var usuarioVM = _mapper.Map<UsuarioViewModel>(Usuario);
            return View(usuarioVM);
        }

        // POST: PadraoReconhecimentoes/Delete/5
        public IActionResult DeleteConfirmed(Guid id)
        {
            _UsuarioServico.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public bool ValidaLogin(string login)
        {
            return _UsuarioServico.LoginExistente(login);
        }

        public bool ValidaUsuario(Usuario usuario)
        {
            return _UsuarioServico.LoginExistente(usuario);
        }

    }
}
