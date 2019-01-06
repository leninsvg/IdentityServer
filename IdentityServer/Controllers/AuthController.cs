using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("login")]
        public async Task<ActionResult> Login()
        {
            var client = new HttpClient();

            //var disco = await client.GetDiscoveryDocumentAsync("https://demo.identityserver.io");
            //if (disco.IsError)
            //{
            //    return Ok(disco.Error);
            //}

            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://identityserver",
                Policy =
                {
                    ValidateIssuerName = false,
                    RequireHttps = false
                }
            });

            if (disco.IsError)
            {
                return Ok(disco.Error);
            }
            var tokenClientRO = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponseRO = await tokenClientRO.RequestResourceOwnerPasswordAsync
                    ("Lenin", "123", "ApiResource");
            if (tokenResponseRO.IsError)
            {
                Console.WriteLine(tokenResponseRO.Error);
                return Ok(tokenResponseRO.Error);
            }
            return Ok(tokenResponseRO.AccessToken);
        }


        /// <summary>
        /// Executes an ICMPv4 PING and returns TRUE if the attempt succeedes, FALSE otherwise
        /// </summary>
        /// <param name="nameOrAddress">IPv4 or Hostname</param>
        /// <returns>TRUE if the given IP/Hostname responds to the ping attempt, FALSE otherwise</returns>
        public static bool PingHost(string nameOrAddress, bool throwExceptionOnError = false)
        {
            bool pingable = false;
            using (Ping pinger = new Ping())
            {
                try
                {
                    PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == IPStatus.Success;
                }
                catch (PingException e)
                {
                    if (throwExceptionOnError) throw e;
                    pingable = false;
                }
            }
            return pingable;
        }
    }
}