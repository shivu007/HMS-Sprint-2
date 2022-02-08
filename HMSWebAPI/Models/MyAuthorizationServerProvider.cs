using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLayer;

namespace HMSWebAPI.Models
{
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            DbHelper dbHelper = new DbHelper();
            var user = dbHelper.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("Invalid User", "Provided Username and Password incorrect");
                return;
            }
            else
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Roles));
                context.Validated(identity);


            }
        }
    }
}