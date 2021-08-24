using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Models.Negocio
{
    /// <summary>
    /// Classe que representa dados de login
    /// </summary>
    public class Login : Entidade
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string NomeUsuario { get; set; }

        /// <summary>
        /// Senha atual
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Nova senha
        /// </summary>
        public string NovaSenha { get; set; }

        /// <summary>
        /// Mensagem
        /// </summary>
        public string Mensagem { get; set; }

    }
}
