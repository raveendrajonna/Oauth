using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using IdentityServer3.Core.Configuration;
using System.Security.Cryptography.X509Certificates;

[assembly: OwinStartup(typeof(OAuth_Examples.Startup))]

namespace OAuth_Examples
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            InmemoryManager inMemMgr = new InmemoryManager();         
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryUsers(inMemMgr.GetUsers())
                .UseInMemoryScopes(inMemMgr.GetScopes())
                .UseInMemoryClients(inMemMgr.GetClients());
            string Certificate = "C:\\Raveendra\\Tools\\RJCert.pfx";    
            var cert2 = new X509Certificate2(Certificate, "password");
            var options = new IdentityServerOptions
            {             
                SigningCertificate = cert2,
                RequireSsl = false,
                Factory = factory
            };
            app.UseIdentityServer(options);
        }
    }
}
