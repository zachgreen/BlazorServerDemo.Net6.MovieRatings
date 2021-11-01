// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Duende.IdentityServer.Models;
using IdentityModel;
using System.Collections.Generic;

namespace BlazorServerDemo.Net6.MovieRatings.Identity
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
                new ApiScope("apis.movies"),
                new ApiScope("apis.movies.read"),
                new ApiScope("apis.movies.write"),

                new ApiScope("apis.favorites"),
                new ApiScope("apis.favorites.read"),
                new ApiScope("apis.favorites.write")
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("apis.movies", "Movies API")
                {
                    Scopes = { "apis.movies.read", "apis.movies.write", JwtClaimTypes.GivenName }
                },
                new ApiResource("apis.favorites", "Favorites API")
                {
                    Scopes = { "apis.favorites.read", "apis.favorites.write", JwtClaimTypes.GivenName }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "web",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:7114/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:7114/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:7114/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", /* grant access for the web client to call the Movies API */ "apis.movies", "apis.movies.read", "apis.movies.write" }
                }
            };
    }
}