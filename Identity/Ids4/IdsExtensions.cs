using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Ids4
{
    public static class IdsExtensions
    {
        public static IServiceCollection AddIds4(this IServiceCollection @this)
        {
            @this.AddAuthentication();

            @this .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(Resources.AllApiScopes)
                //.AddInMemoryIdentityResources(Resources.AllIdentityResources)
                .AddInMemoryApiResources(Resources.AllApiResources)
                .AddInMemoryClients(Clients.All)
          // .AddTestUsers(OAuthMemoryData.GetTestUsers());
          .AddProfileService<ProfileService>()
         .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();
            return @this;

        }

        public static IApplicationBuilder UseIds4(this IApplicationBuilder @this)
        {
            return @this.UseIdentityServer();
        }

        private static void SetIdentityServerOptions(IdentityServerOptions options)
        {
            options.IssuerUri = "http://localhost/ids4JsClient";
            options.UserInteraction = new UserInteractionOptions
            {
                LoginUrl = "/index.html",
                LogoutUrl = "/account/logout",
                LogoutIdParameter = "logoutId",
                ErrorUrl = "/ids4/error",
                ErrorIdParameter = "errorId"
            };
        }
    }
}
