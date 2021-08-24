namespace Controle_Ativos.BLL.Models.Login
{
    /// <summary>
    /// Classe que representa os usuarios do sistema Meta3AI
    /// </summary>
    public  class Usuario : Entidade
    {
        /// <summary>
        /// Nome do usuário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Email do usuário
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Define se o usuário está ativo 
        /// </summary>
        public bool Ativo { get; set; }

        /// <summary>
        /// Define se o usuário é administrador do sistema
        /// </summary>
        public bool Admin { get; set; }       
    }
}
