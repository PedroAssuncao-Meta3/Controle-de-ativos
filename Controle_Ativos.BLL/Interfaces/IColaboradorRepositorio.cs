using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Interfaces
{
    public interface IColaboradorRepositorio : IRepositorio<Colaborador>
    {
        List<Cliente> RecuperaListaCliente();
    }
}
