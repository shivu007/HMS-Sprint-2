using HMSWebAPI.Models;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(HMSWebAPI.App_Start.Startup))]

namespace HMSWebAPI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
                // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
                OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
                {
                    AllowInsecureHttp = true,
                    TokenEndpointPath = new PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    Provider = new MyAuthorizationServerProvider()
                };

                app.UseOAuthAuthorizationServer(options);
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
           
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
