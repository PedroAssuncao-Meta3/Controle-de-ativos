using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Controle_Ativos.Config
{
    public static class AssemblyUtils
    {
        private static string NomeProjeto(string camada) => typeof(AssemblyUtils).Namespace.Replace("Infra", camada);

        /// <summary>
        /// Recupera todas as interfaces que devem ser injetadas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> RecuperaInterfaces()
        {
            return RecuperaTiposDefinidos("BLL", tipo => tipo.IsInterface && tipo.Namespace != null && ValidaNamespace(tipo, "BLL.Interfaces"));
        }

        /// <summary>
        /// Recupera todoas classes que devem ser injetadas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> RecuperaClasses(string[] camadasServico)
        {
            List<Type> retorno = new List<Type>();

            retorno.AddRange(RecuperaServicosClasses(camadasServico));
            retorno.AddRange(RecuperaDataClasses());

            return retorno;
        }

        /// <summary>
        /// Retorna todos os objetos das camadas de serviço que devem ser injetados.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> RecuperaServicosClasses(string[] camadasServico)
        {
            List<Type> retorno = new List<Type>();
            
            foreach (var servico in camadasServico)
            {
                retorno.AddRange(RecuperaTiposDefinidos(servico, tipo => tipo.IsClass && !tipo.IsAbstract && tipo.Namespace != null &&
                                                                         tipo.GetCustomAttribute<CompilerGeneratedAttribute>() == null));
            }

            return retorno;
        }

        /// <summary>
        /// Retorna todos os objetos que devem ser injetados da camada de Data
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> RecuperaDataClasses()
        {
            return RecuperaTiposDefinidos("Data", tipo => tipo.IsClass && !tipo.IsAbstract && tipo.Namespace != null &&
                                                          tipo.GetCustomAttribute<CompilerGeneratedAttribute>() == null &&
                                                          (ValidaNamespace(tipo, "Data.Repositorios")));
        }

        /// <summary>
        /// Valida se o tipo pertence ja algum namespace dentro da camada informada.
        /// </summary>
        /// <param name="tipo">Tipo</param>
        /// <param name="nomeCamada"> Nome da Camada</param>
        /// <returns></returns>
        private static bool ValidaNamespace(Type tipo, string nomeCamada)
        {
            return tipo.Namespace.StartsWith(NomeProjeto(nomeCamada));
        }

        /// <summary>
        /// Recupera a lista de tipos da camada
        /// </summary>
        /// <param name="nomeCamada">Nome da camada do projeto</param>
        /// <returns></returns>
        private static Type[] RecuperaTiposDefinidos(string nomeCamada, Func<Type, bool> filtro = null)
        {
            var retorno = Assembly.Load(NomeProjeto(nomeCamada)).GetTypes();
            if (filtro != null)
            {
                return retorno.Where(filtro).ToArray();
            }
            else
            {
                return retorno;
            }
        }

        /// <summary>
        /// Metodo que recebe um tipo interface e retorna a classe que implementa a mesma.
        /// </summary>
        /// <param name="tipoInterface">Interface no qual deseja recuperar a classe</param>
        /// <param name="listaTipos">Lista de classes</param>
        /// <returns></returns>
        public static Type BuscaTipoClasse(Type tipoInterface, IEnumerable<Type> listaTipos)
        {
            return listaTipos.FirstOrDefault(t => t.GetInterfaces().Contains(tipoInterface));
        }

        /// <summary>
        /// Metodo que recebe um tipo classe e retorna a interface que a mesma implementa
        /// </summary>
        /// <param name="tipoClasse">Classe no qual se deseja recuperar a interface </param>
        /// <param name="listaInterfaces">Lista de intefaces</param>
        /// <returns></returns>
        public static Type BuscaTipoInterface(Type tipoClasse, IEnumerable<Type> listaInterfaces)
        {
            return listaInterfaces.FirstOrDefault(i => tipoClasse.GetInterfaces().Contains(i));
        }

    }
}
