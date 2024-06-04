using Catalog.API.Exceptions;
using Catalog.API.Models;
using Catalog.API.Products.UpdateProduct;
using Marten;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Api.Unit.Tests.Handlers
{
    public class UpdateProductCommandHandlerTests
    {
        [Fact]
        public void It_Should_Return_Message_If_Product_NotFound()
        {
            // Arrange
            var documentSessionMock = new Mock<IDocumentSession>();
            var id = Guid.NewGuid();
            var product = new Product { Id = id, Name = "Test Product" };
            documentSessionMock.Setup(s => s.LoadAsync<Product>("123", It.IsAny<CancellationToken>()))
                    .ReturnsAsync(product);

            // Act
            var handler = new UpdateProductCommandHandler(documentSessionMock.Object);
            var command = new UpdateProductCommand(
                Guid.NewGuid(), 
                "NewName", 
                ["New Category"], 
                "New Description", 
                "New ImageFile", 
                10);

            

            // Assert
            Should.ThrowAsync<ProductNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
