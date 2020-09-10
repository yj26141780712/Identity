using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Ids4
{
    public static class Resources
    {

        public static IEnumerable<IdentityResource> AllIdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> AllApiScopes => new List<ApiScope>
        {
            new ApiScope("api-1", "Scope 1"),
            new ApiScope("api-2", "Scope 2"),
            new ApiScope("api-3", "Scope 3")
        };

        public static IEnumerable<ApiResource> AllApiResources => new List<ApiResource>
        {
            new ApiResource("api", "Some API")
            { 
                Scopes= AllApiScopes.Select(x=>x.Name).ToList()
            }
        };

    }
}
