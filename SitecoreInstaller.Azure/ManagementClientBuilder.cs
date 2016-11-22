using System;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace SitecoreInstaller.Azure
{
    public class ManagementClientBuilder
    {
        public async Task<ResourceManagementClient> CreateAsync(DeploymentCredentials credentials)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));
            var serviceCredentials = await ToServiceClientCredentialsAsync(credentials).ConfigureAwait(false);
            return Create(serviceCredentials, credentials.SubscriptionId);
        }

        public ResourceManagementClient Create(ServiceClientCredentials credentials, string subscriptionId)
        {
            if (credentials == null) throw new ArgumentNullException(nameof(credentials));
            if (subscriptionId == null) throw new ArgumentNullException(nameof(subscriptionId));
            return new ResourceManagementClient(credentials)
            {
                SubscriptionId = subscriptionId
            };
        }

        private async Task<ServiceClientCredentials> ToServiceClientCredentialsAsync(DeploymentCredentials credentials)
        {
            var authContext = new AuthenticationContext($"https://login.windows.net/{credentials.TenantId}");
            var credential = new ClientCredential(credentials.AppId, credentials.AppSecret);
            var result = await authContext.AcquireTokenAsync(resource: "https://management.core.windows.net/", clientCredential: credential).ConfigureAwait(false);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return new TokenCredentials(result.AccessToken);
        }
    }
}
