using Catalog.API.Products.GetProducts;
using Marten;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Api.Unit.Tests.Handlers
{
    public class GetProductsQueryHandlerTests
    {
        [Fact]
        public async Task It_Should_Return_List_Product()
        {
            // Arrange
            var documentSessionMock = new Mock<IDocumentSession>();

            // Act
            var query = new GetProductsQuery(1, 2);
            var handler = new GetProductsQueryHandler(documentSessionMock.Object);
            var result = await handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result.Products);

        }
    }
}
