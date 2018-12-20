using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
	public class Config
	{
		public static IEnumerable<ApiResource> GetAllApiResources()
		{
			return new List<ApiResource>()
			{
				new ApiResource("ApiResource", "Customer of api for bankOfDotNetApi")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>()
			{
				new Client()
				{
					ClientId = "client1",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("secret".Sha256())
					},
					AllowedScopes = { "ApiResource" }
				}
			};
		}
	}
}
