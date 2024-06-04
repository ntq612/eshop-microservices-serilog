using Catalog.API.Products.DeleteProduct;

namespace Catalog.Api.Unit.Tests.Validators
{
    public class DeleteProductCommandValidatorTests
    {
        [Fact]
        public void It_Should_Return_Message_If_ProductId_Null()
        {
            // Arrange
            var command = new DeleteProductCommand(Guid.Empty);

            // Act
            var validator = new DeleteProductCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Product ID is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void It_Should_Return_Success()
        {
            // Arrange
            var command = new DeleteProductCommand(Guid.Empty);

            // Act
            var validator = new DeleteProductCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Product ID is required", result.Errors[0].ErrorMessage);
        }
    }
}
