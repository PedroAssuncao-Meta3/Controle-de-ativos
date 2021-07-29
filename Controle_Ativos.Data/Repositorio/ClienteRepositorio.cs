using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(DBContexto context) : base(context) { }

        public List<Cliente> BuscarPorNome(string nome)
        { 
            return this.Buscar(tab => tab.Nome == nome).ToList();
        }

    }
}
