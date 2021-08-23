using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace Controle_Ativos.Config
{
    /// <summary>
    /// Classe responsável pela configuração de cultura da aplicação
    /// </summary>
    public static class GlobalizaoPadrao
    {

        /// <summary>
        /// Configuração da cultura da aplicação.
        /// </summary>
        /// <param name = "app" ></ param >
        /// < returns ></ returns >
        public static IApplicationBuilder ConfiguracaoGlobalizao(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(RecuperaConfigPadrao());
            return app;
        }
                
        public static RequestLocalizationOptions RecuperaConfigPadrao()
        {
            var defaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            return localizationOptions;
        }
    }

}

