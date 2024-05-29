﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "catalogClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "catalogAPI" }
                },
                new Client
                {
                    ClientId = "basketClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "basketAPI" }
                },
                new Client
                {
                    ClientId = "shopping_mvc_client",
                    ClientName = "Shopping MVC Web App",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "catalogAPI",
                        "basketAPI",
                        "roles"
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("catalogAPI", "Catalog API"),
                new ApiScope("basketAPI", "Basket API")
            };

        public static IEnumerable<ApiResource> ApiResources => 
            new ApiResource[] 
            { 
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "ntq612",
                    Password = "Aa@123456",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "trongquy"),
                        new Claim(JwtClaimTypes.FamilyName, "nguyen"),
                        new Claim(JwtClaimTypes.Role, "Admin")
                    }
                }
            };
    }
}
