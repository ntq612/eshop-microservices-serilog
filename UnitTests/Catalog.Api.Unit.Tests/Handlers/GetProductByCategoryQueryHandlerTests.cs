using Catalog.API.Models;
using Catalog.API.Products.GetProductByCategory;
using Marten;
using Marten.Linq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Api.Unit.Tests.Handlers
{
    public class GetProductByCategoryQueryHandlerTests
    {
        //[Fact]
        //public async Task It_Should_Return_List_Product()
        //{
        //    // Arrange
        //    var documentSessionMock = new Mock<IDocumentSession>();
        //    var id = Guid.NewGuid();
        //    var mockProducts = new List<Product>
        //    {
        //        new Product { Id = Guid.NewGuid(), Name = "Product 1", Category = { "Category A" } },
        //        new Product { Id = Guid.NewGuid(), Name = "Product 2", Category = { "Category A" } },
        //        new Product { Id = Guid.NewGuid(), Name = "Product 3", Category = { "Category B" } }
        //    };
        //    var mockQueryable = mockProducts.AsQueryable().Cast<Product>(); // Explicitly cast to Product

        //    documentSessionMock.Setup(s => s.Query<Product>())
        //        .Returns((IMartenQueryable<Product>)mockQueryable);

        //    // Act
        //    var handler = new GetProductByCategoryQueryHandler(documentSessionMock.Object);
        //    var query = new GetProductByCategoryQuery(Category: "Category A");
        //    var result = await handler.Handle(query, new CancellationToken());

        //    // Assert
        //    Assert.True(result == null);
        //}
    }
}
