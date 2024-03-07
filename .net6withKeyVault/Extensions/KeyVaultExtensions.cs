using Azure.Identity;

namespace DominioServico.Api.Extensions
{
    public static class KeyVaultExtensions
    {
        public static void UseKeyVault(this WebApplicationBuilder builder)
        {
            try
            {
                string tenantId = Environment.GetEnvironmentVariable("TENANT_ID") ?? builder.Configuration["tenantId"] ?? string.Empty;
                string clientId = Environment.GetEnvironmentVariable("CLIENT_ID") ?? builder.Configuration["clientId"] ?? string.Empty;
                string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET") ?? builder.Configuration["clientSecret"] ?? string.Empty;
                string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME") ?? builder.Configuration["keyVaultName"] ?? string.Empty;

                ClientSecretCredential credential = new(tenantId, clientId, clientSecret);

                string KeyVaultBaseUrl = $"https://{keyVaultName}.vault.azure.net/";

                builder.Configuration.AddAzureKeyVault(new Uri(KeyVaultBaseUrl), credential);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao configurar o KeyVault", ex);
            }
        }
    }
}