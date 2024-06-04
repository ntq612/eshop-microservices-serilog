using Basket.API.Basket.CheckoutBasket;

namespace Basket.Api.Unit.Tests.Validators
{
    public class CheckoutBasketCommandValidatorTests
    {

        [Fact]
        public void It_Should_Throw_Message_BasketCheckoutDto_IsNull()
        {
            // Arrange
            var command = new CheckoutBasketCommand(null);

            // Act
            var validator = new CheckoutBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("BasketCheckoutDto can't be null", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void It_Should_Throw_Message_If_UserName_IsEmpty()
        {
            // Arrange
            var command = new CheckoutBasketCommand(new API.Dtos.BasketCheckoutDto
            {
                UserName = ""
            });

            // Act
            var validator = new CheckoutBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("UserName is required", result.Errors[0].ErrorMessage);
        }

        [Fact]
        public void It_Should_Throw_Message_If_UserName_IsNull()
        {
            // Arrange
            var command = new CheckoutBasketCommand(new API.Dtos.BasketCheckoutDto
            {
                UserName = null
            });

            // Act
            var validator = new CheckoutBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("UserName is required", result.Errors[0].ErrorMessage);
        }
    }
}
