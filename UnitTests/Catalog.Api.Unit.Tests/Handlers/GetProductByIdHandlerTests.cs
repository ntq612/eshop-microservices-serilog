using Catalog.API.Exceptions;
using Catalog.API.Models;
using Catalog.API.Products.GetProductById;
using Marten;
using Moq;
using Shouldly;

namespace Catalog.Api.Unit.Tests.Handlers
{
    public class GetProductByIdHandlerTests
    {
        [Fact]
        public async Task It_Should_Return_Exception_When_Product_NotFound()
        {
            // Arrange
            var documentSessionMock = new Mock<IDocumentSession>();
            var id = new Guid();
            var product = new Product { Id = id, Name = "Test Product" };
            documentSessionMock.Setup(s => s.LoadAsync<Product>("123", It.IsAny<CancellationToken>()))
                    .ReturnsAsync(product);

            // Act
            var handler = new GetProductByIdQueryHandler(documentSessionMock.Object);
            var query = new GetProductByIdQuery(id);

            // Assert
            await Should.ThrowAsync<ProductNotFoundException>(() => handler.Handle(query, CancellationToken.None));
        }

        [Fact]
        public async Task It_Should_Return_Product()
        {
            // Arrange
            var documentSessionMock = new Mock<IDocumentSession>();
            var id = new Guid();
            var product = new Product { Id = id, Name = "Test Product" };
            documentSessionMock.Setup(s => s.LoadAsync<Product>(id, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(product);

            // Act
            var handler = new GetProductByIdQueryHandler(documentSessionMock.Object);
            var query = new GetProductByIdQuery(id);
            var result = await handler.Handle(query, new CancellationToken());

            // Arrange
            Assert.NotNull(result.Product);
        }
    }
}
