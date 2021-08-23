using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Controle_Ativos.Config
{
    public class InjecaoDependenciaUtils : IDisposable
    {

        public InjecaoDependenciaUtils()
        {

        }

        public void Executar(IServiceCollection services, string aplicativo, string[] camadasServico = null)
        {
            InjetaDependencia(services, aplicativo, camadasServico);
        }


        private void InjetaDependencia(IServiceCollection services, string aplicativo, string[] camadasServico = null)
        {
            var listaInterface = this.RecuperaInterfaces(aplicativo);
            var ListaClasses = this.RecuperaClasses(aplicativo, camadasServico);

            foreach (var tipoInterface in listaInterface)
            {
                var tipoClasse = this.BuscaTipoClasse(tipoInterface, ListaClasses);

                if (tipoClasse != null)
                {
                    services.AddScoped(tipoInterface, tipoClasse);
                }
            }
        }

        private string NomeProjeto(string aplicativo, string camada) => string.Format("{0}.{1}", aplicativo, camada);

        /// <summary>
        /// Recupera todas as interfaces que devem ser injetadas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> RecuperaInterfaces(string aplicativo)
        {
            return RecuperaTiposDefinidos(aplicativo, "BLL", tipo => tipo.IsInterface && tipo.Namespace != null && ValidaNamespace(tipo, aplicativo, "BLL.Interfaces"));
        }

        /// <summary>
        /// Recupera todoas classes que devem ser injetadas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> RecuperaClasses(string aplicativo, string[] camadasServico)
        {
            List<Type> retorno = new List<Type>();
            if (camadasServico != null && camadasServico.Length > 0)
            {
                retorno.AddRange(RecuperaServicosClasses(aplicativo, camadasServico));
            }

            retorno.AddRange(RecuperaDataClasses(aplicativo));

            return retorno;
        }

        /// <summary>
        /// Retorna todos os objetos das camadas de serviço que devem ser injetados.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> RecuperaServicosClasses(string aplicativo, string[] camadasServico)
        {
            List<Type> retorno = new List<Type>();

            foreach (var servico in camadasServico)
            {
                retorno.AddRange(RecuperaTiposDefinidos(aplicativo, servico, tipo => tipo.IsClass && !tipo.IsAbstract && tipo.Namespace != null &&
                                                                         tipo.GetCustomAttribute<CompilerGeneratedAttribute>() == null));
            }

            return retorno;
        }

        /// <summary>
        /// Retorna todos os objetos que devem ser injetados da camada de Data
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Type> RecuperaDataClasses(string aplicativo)
        {
            return RecuperaTiposDefinidos(aplicativo, "Data", tipo => tipo.IsClass && !tipo.IsAbstract && tipo.Namespace != null &&
                                                          tipo.GetCustomAttribute<CompilerGeneratedAttribute>() == null &&
                                                          (ValidaNamespace(tipo, aplicativo, "Data.Repositorio")));
        }

        /// <summary>
        /// Valida se o tipo pertence ja algum namespace dentro da camada informada.
        /// </summary>
        /// <param name="tipo">Tipo</param>
        /// <param name="nomeCamada"> Nome da Camada</param>
        /// <returns></returns>
        private bool ValidaNamespace(Type tipo, string aplicativo, string nomeCamada)
        {
            return tipo.Namespace.StartsWith(NomeProjeto(aplicativo, nomeCamada));
        }

        /// <summary>
        /// Recupera a lista de tipos da camada
        /// </summary>
        /// <param name="nomeCamada">Nome da camada do projeto</param>
        /// <returns></returns>
        private Type[] RecuperaTiposDefinidos(string aplicativo, string nomeCamada, Func<Type, bool> filtro = null)
        {
            var retorno = Assembly.Load(NomeProjeto(aplicativo, nomeCamada)).GetTypes();
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
        public Type BuscaTipoClasse(Type tipoInterface, IEnumerable<Type> listaTipos)
        {
            return listaTipos.FirstOrDefault(t => t.GetInterfaces().Contains(tipoInterface));
        }

        /// <summary>
        /// Metodo que recebe um tipo classe e retorna a interface que a mesma implementa
        /// </summary>
        /// <param name="tipoClasse">Classe no qual se deseja recuperar a interface </param>
        /// <param name="listaInterfaces">Lista de intefaces</param>
        /// <returns></returns>
        public Type BuscaTipoInterface(Type tipoClasse, IEnumerable<Type> listaInterfaces)
        {
            return listaInterfaces.FirstOrDefault(i => tipoClasse.GetInterfaces().Contains(i));
        }

        public void Dispose()
        {

        }
    }
}
