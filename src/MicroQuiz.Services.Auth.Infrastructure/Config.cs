using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MicroQuiz.Services.Auth.Infrastructure
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
            => new List<ApiResource>
            {
                new ApiResource("quiz-api", "Public MicroQuiz API")
            };

        public static IEnumerable<Client> GetClients()
            => new List<Client>
            {
                new Client
                {
                    ClientId = "api",
                    ClientName = "API Gateway",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "quiz-api"
                    }
                },
            };

        public static IEnumerable<IdentityResource> GetIdentityResources()
            => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
