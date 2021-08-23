using Controle_Ativos.Data.Contexto;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.Config.Global
{
   public static class InjecaoDependencia
    { 
        
        /// <summary>
      /// Configuração das injeções de dependências
      /// </summary>
      /// <param name="services"></param>
      /// <returns></returns>
        public static IServiceCollection ResolveDependencias(this IServiceCollection services)
        {
            services.AddScoped<DBContexto>();

            using (InjecaoDependenciaUtils objInjDep = new InjecaoDependenciaUtils())
            {
                objInjDep.Executar(services, "Controle_Ativos", new string[] { "Service" });
            }

            return services;
        }

    }
}
