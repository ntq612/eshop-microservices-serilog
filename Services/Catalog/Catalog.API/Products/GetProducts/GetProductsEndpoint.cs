using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Catalog.API.Products.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            //// 1 - retrieve our api credentials
            //var apiClientCredential = new ClientCredentialsTokenRequest
            //{
            //    Address = "https://localhost:5015/connect/token",

            //    ClientId = "catalogClient",

            //    ClientSecret = "secret",

            //    Scope = "catalogAPI"
            //};

            //var client = new HttpClient();

            //var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5015");

            //if (disco.IsError)
            //{
            //    return null;
            //};

            //// 2 - Authenticate and get access token from Identity Server
            //var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCredential);

            //if(tokenResponse.IsError)
            //{
            //    return null;
            //}

            //var apiClient = new HttpClient();

            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            var query = request.Adapt<GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        //.RequireAuthorization()
        //.RequireAuthorization("ClientIdPolicy")
        //.RequireAuthorization("RequiredAdmin")
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
