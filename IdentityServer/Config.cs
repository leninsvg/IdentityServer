using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
	public class Config
	{
        // Implicit folw identity resources
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {
                new TestUser()
                {
                    SubjectId ="1",
                    Username = "Lenin",
                    Password = "123"
                },
                new TestUser()
                {
                    SubjectId ="1",
                    Username = "Hi",
                    Password = "123"
                }
            };
        }
		public static IEnumerable<ApiResource> GetAllApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("ApiResource", "Customer of api for bankOfDotNetApi")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			// Client-Credential base grant type
			return new List<Client>()
			{
				new Client()
				{
					ClientId = "client",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},
					AllowedScopes = { "ApiResource" }
				},
                // Resource Ouner Paswword grant type
                new Client()
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "ApiResource" }
                },
                // ImplicitFlow grant type
                new Client()
                {
                    ClientId = "mvcClient",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = {"http://localhost:5003/signin-oidc"},
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
		}
	}
}
