using Controle_Ativos.BLL.Interfaces.Servicos.Login;
using Controle_Ativos.BLL.Models.Login;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Controle_Ativos.WebAPI.Controllers
{
    /// <summary>
    /// Serviço de Usuários
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioServico _usuarioServico;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="usuarioServico"></param>
        public UsuarioController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        /// <summary>
        /// Recupera o usuario pelo ID
        /// </summary>
        /// <param name="id">ID da usuario</param>
        /// <returns></returns>
        [HttpGet("Obter/{id}")]
        public ActionResult<Usuario> Obter(Guid id)
        {
            var Usuario = _usuarioServico.ObterPorId(id);

            if (Usuario == null)
            {
                return NotFound();
            }
            return Usuario;
        }

        /// <summary>
        /// Recupera todos os Usuarios inseridos no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterTodos")]
        public ActionResult<IEnumerable<Usuario>> ObterTodos()
        {
            return _usuarioServico.ObterTodos();
        }

        /// <summary>
        /// Insere o registro de Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("Inserir")]
        public IActionResult Inserir(Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            try
            {
                _usuarioServico.Adicionar(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Insere o registro de varios Usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost("InserirLista")]
        public IActionResult InserirLista(List<Usuario> usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            try
            {               
                _usuarioServico.AdicionarLista(usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Atualiza o registro de Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        [HttpPost("Atualizar")]
        public IActionResult Atualizar(Usuario Usuario)
        {
            try
            {
                if (Usuario == null)
                {
                    return BadRequest();
                }

                _usuarioServico.Atualizar(Usuario);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Excluir o registra Usuario pelo ID
        /// </summary>
        /// <param name="id">ID da usuario</param>
        /// <returns></returns>
        [HttpDelete("Excluir/{id}")]
        public ActionResult Excluir(Guid id)
        {
            try
            {
                _usuarioServico.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Exclui todos os registros de usuario do banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpDelete("ExcluirTodos")]
        public IActionResult ExcluirTodos()
        {
            try
            {
                _usuarioServico.RemoverTodos();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
