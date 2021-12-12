// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace SatoshiApp.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                       new IdentityResources.Email(),
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile()
                   };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("satoshiapi", "Satoshi System API",new List<string> { "role" })
                {
                    ApiSecrets = { new Secret("FGK$DEF1487jh&^$shcbDIF%".Sha256()) }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("satoshiapi", "Satoshi API")
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration) =>
            new Client[]
            {
                new Client
                {
                    ClientId = "customerapicode",
                    ClientName = "Customer API Code",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = new []
                    {
                        "https://localhost:44330/swagger/oauth2-redirect.html",
                        "https://localhost:44330/oauth2-redirect.html",
                        "http://localhost:9002/swagger/oauth2-redirect.html",
                        "http://localhost:9002/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiCustomerApi/swagger/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiCustomerApi/oauth2-redirect.html",
                        "http://localhost/SatoshiCustomerApi/swagger/oauth2-redirect.html",
                        "http://localhost/SatoshiCustomerApi/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new []
                    {
                        "https://localhost:44330/swagger/signout-callback-oidc",
                        "https://localhost:44330/signout-callback-oidc",
                        "http://localhost:9002/swagger/signout-callback-oidc",
                        "http://localhost:9002/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiCustomerApi/swagger/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiCustomerApi/signout-callback-oidc",
                        "http://localhost/SatoshiCustomerApi/swagger/signout-callback-oidc",
                        "http://localhost/SatoshiCustomerApi/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "https://localhost:44330",
                        "http://localhost:9002",
                        "http://codelearnersoft.net",
                        "http://localhost"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "satoshiapi"
                    }
                },

                new Client
                {
                    ClientId = "productapicode",
                    ClientName = "Product API Code",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = new []
                    {
                        "https://localhost:49153/swagger/oauth2-redirect.html",
                        "https://localhost:49153/oauth2-redirect.html",
                        "http://localhost:9003/swagger/oauth2-redirect.html",
                        "http://localhost:9003/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiProductApi/swagger/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiProductApi/oauth2-redirect.html",
                        "http://localhost/SatoshiProductApi/swagger/oauth2-redirect.html",
                        "http://localhost/SatoshiProductApi/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new []
                    {
                        "https://localhost:49153/swagger/signout-callback-oidc",
                        "https://localhost:49153/signout-callback-oidc",
                        "http://localhost:9003/swagger/signout-callback-oidc",
                        "http://localhost:9003/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiProductApi/swagger/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiProductApi/signout-callback-oidc",
                        "http://localhost/SatoshiProductApi/swagger/signout-callback-oidc",
                        "http://localhost/SatoshiProductApi/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "https://localhost:49153",
                        "http://localhost:9003",
                        "http://codelearnersoft.net",
                        "http://localhost"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "satoshiapi"
                    }
                },

                new Client
                {
                    ClientId = "orderapicode",
                    ClientName = "Order API Code",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = new []
                    {
                        "https://localhost:44396/swagger/oauth2-redirect.html",
                        "https://localhost:44396/oauth2-redirect.html",
                        "http://localhost:9004/swagger/oauth2-redirect.html",
                        "http://localhost:9004/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiOrderApi/swagger/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiOrderApi/oauth2-redirect.html",
                        "http://localhost/SatoshiOrderApi/swagger/oauth2-redirect.html",
                        "http://localhost/SatoshiOrderApi/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new []
                    {
                        "https://localhost:44396/swagger/signout-callback-oidc",
                        "https://localhost:44396/signout-callback-oidc",
                        "http://localhost:9004/swagger/signout-callback-oidc",
                        "http://localhost:9004/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiOrderApi/swagger/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiOrderApi/signout-callback-oidc",
                        "http://localhost/SatoshiOrderApi/swagger/signout-callback-oidc",
                        "http://localhost/SatoshiOrderApi/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "https://localhost:44396",
                        "http://localhost:9004",
                        "http://codelearnersoft.net",
                        "http://localhost"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "satoshiapi"
                    }
                },

                new Client
                {
                    ClientId = "userapicode",
                    ClientName = "User API Code",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = new []
                    {
                        "https://localhost:44375/swagger/oauth2-redirect.html",
                        "https://localhost:44375/oauth2-redirect.html",
                        "http://localhost:9001/swagger/oauth2-redirect.html",
                        "http://localhost:9001/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiOrderApi/swagger/oauth2-redirect.html",
                        "http://codelearnersoft.net/SatoshiOrderApi/oauth2-redirect.html",
                        "http://localhost/SatoshiOrderApi/swagger/oauth2-redirect.html",
                        "http://localhost/SatoshiOrderApi/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris = new []
                    {
                        "https://localhost:44375/swagger/signout-callback-oidc",
                        "https://localhost:44375/signout-callback-oidc",
                        "http://localhost:9001/swagger/signout-callback-oidc",
                        "http://localhost:9001/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiUserApi/swagger/signout-callback-oidc",
                        "http://codelearnersoft.net/SatoshiUserApi/signout-callback-oidc",
                        "http://localhost/SatoshiUserApi/swagger/signout-callback-oidc",
                        "http://localhost/SatoshiUserApi/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "https://localhost:44375",
                        "http://localhost:9001",
                        "http://codelearnersoft.net",
                        "http://localhost"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "satoshiapi"
                    }
                },

                new Client
                {
                    ClientId = "satoshiuicode",
                    ClientName = "Satoshi UI Code",
                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowRememberConsent = true,
                    AllowOfflineAccess = true,
                    RedirectUris = new []
                    {
                        "https://localhost:44315/dashboard",
                        "https://localhost:9005/dashboard",
                        "http://codelearnersoft.net/SatoshiUI/dashboard",
                        "http://localhost/SatoshiUI/swagger/dashboard"
                    },
                    PostLogoutRedirectUris = new []
                    {
                        "https://localhost:44315/home",
                        "https://localhost:9005/home",
                        "http://codelearnersoft.net/SatoshiUI/home",
                        "http://localhost/SatoshiUI/swagger/home"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "https://localhost:44315",
                        "https://localhost:9005",
                        "http://codelearnersoft.net",
                        "http://localhost"
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "satoshiapi"
                    }
                }
            };
    }
}