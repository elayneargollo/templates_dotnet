using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Comunicacao.Messagem.Configuration
{
    public class ConfiguracaoAppSettings : IConfiguracaoAppSettings
    {
        private System.Collections.Specialized.NameValueCollection configuracaoAplicacao = ConfigurationManager
                                    .GetSection("ApplicationSettings")  as NameValueCollection;

        public string GetValueKey(string chave)
        {
            foreach (var key in configuracaoAplicacao.AllKeys)
            {
                if(key.Equals(chave))
                    return configuracaoAplicacao[key];
            }

            throw new Exception("A seção ConfiguracaoAplicacao não esta definida");
        }
    }
}