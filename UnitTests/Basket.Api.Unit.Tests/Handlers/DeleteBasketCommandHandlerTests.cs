using Basket.API.Basket.DeleteBasket;
using Basket.API.Data;
using Basket.API.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Unit.Tests.Handlers
{
    public class DeleteBasketCommandHandlerTests
    {
        [Fact]
        public void It_Should_Return_True_When_Delete_Basket()
        {
            // Arrange
            var basketRepositoryMock = new Mock<IBasketRepository>();

            var shoppingCart = new API.Models.ShoppingCart();
            basketRepositoryMock.Setup(x => x.GetBasket(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(shoppingCart);

            // Act
            var handler = new DeleteBasketCommandHandler(basketRepositoryMock.Object);
            var command = new DeleteBasketCommand("testusername");
            var result = handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
