using Basket.API.Basket.DeleteBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Unit.Tests.Validators
{
    public class DeleteBasketCommandValidatorTests
    {
        [Fact]
        public void It_Should_Throw_Message_If_Username_Null_Delete_Basket()
        {
            // Arrange
            var command = new DeleteBasketCommand(null);

            // Act
            var validator = new DeleteBasketCommandValidator();
            var result = validator.Validate(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("UserName is required", result.Errors.First().ErrorMessage);
        }
    }
}
