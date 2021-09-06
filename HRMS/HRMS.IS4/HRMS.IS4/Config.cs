// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace HRMS.IS4
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ApiScope"),
                new ApiScope("FrontScope"),
                new ApiScope("email")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "HRMS.WebApi",
                    ClientName = "HRMS Api",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "ApiScope" }
                },
                new Client
                {
                    ClientId = "InventoryApi",
                    ClientName = "HRMS Inventory API",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "ApiScope" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "Angular",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost:4200" },
                    FrontChannelLogoutUri = "http://localhost:4200",
                    PostLogoutRedirectUris = { "http://localhost:4200" },

                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "email", "FrontScope" }
                },
            };
    }
}