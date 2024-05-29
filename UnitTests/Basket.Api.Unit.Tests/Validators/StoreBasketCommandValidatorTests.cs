using Basket.API.Basket.StoreBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Unit.Tests.Validators
{
    public class StoreBasketCommandValidatorTests
    {
        [Fact]
        public void It_Should_Throw_Message_If_Cart_IsNull()
        {
            // Arrange
            var command = new StoreBasketCommand(null);

            // Act
            var validator = new StoreBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("Cart can not be null", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void It_Should_Throw_Message_If_Username_IsEmpty()
        {
            // Arrange
            var command = new StoreBasketCommand(new API.Models.ShoppingCart
            {
                UserName = ""
            });

            // Act
            var validator = new StoreBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("UserName is required", result.Errors[0].ErrorMessage);

        }

        [Fact]
        public void It_Should_Throw_Message_If_Username_IsNull()
        {
            // Arrange
            var command = new StoreBasketCommand(new API.Models.ShoppingCart
            {
                UserName = null
            });

            // Act
            var validator = new StoreBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsValid);
            Assert.Equal("UserName is required", result.Errors[0].ErrorMessage);

        }
    }
}
