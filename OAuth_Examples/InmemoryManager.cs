using IdentityServer3.Core;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace OAuth_Examples
{
    public class InmemoryManager
    {
        public List<InMemoryUser> GetUsers()
        {
            return new List<InMemoryUser>()
            {
                new InMemoryUser() {Subject ="XYZ", Username = "XYZ.gmail.com",Password="123", Claims=new[] { new Claim(Constants.ClaimTypes.Name,"xyz") } },
                          new InMemoryUser() {Subject ="abc", Username = "abc.gmail.com",Password="123", Claims=new[] { new Claim(Constants.ClaimTypes.Name,"abc") } },
                          new InMemoryUser() {Subject ="pqr", Username = "pqr.gmail.com",Password="123", Claims=new[] { new Claim(Constants.ClaimTypes.Name,"pqr") } }
            };
        }

        public IEnumerable<Scope> GetScopes()
        {
            return new[]
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.OfflineAccess,
                new Scope {Name ="Read", DisplayName ="Read only Data" }
            };
        }


        public IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId ="ClientID1",
                    ClientSecrets = new List<Secret> {
                                            new Secret("Secret".Sha256())
                                           },
                    ClientName ="ClientName1",
                    Flow=Flows.ResourceOwner,
                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        "read"
                    }
                }
            };
        }
    }
}