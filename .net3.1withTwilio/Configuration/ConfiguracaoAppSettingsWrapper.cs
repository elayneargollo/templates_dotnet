using Comunicacao.Messagem.Configuration;

namespace Comunicacao.Messagem
{
    public class ConfiguracaoAppSettingsWrapper : IConfiguracaoAppSettings
    {
        public string GetValueKey(string key)
        {
            var configuracaoAppSettings = new ConfiguracaoAppSettings();
            return configuracaoAppSettings.GetValueKey(key);
        }
    }
}