using Basket.API.Basket.CheckoutBasket;
using Basket.API.Data;
using MassTransit;
using Moq;

namespace Basket.Api.Unit.Tests.Handlers
{
    public class CheckoutBasketCommandHandlerTests
    {
        [Fact]
        public async Task It_Should_Return_FalseResult_If_BasketNotFoundInDatabase()
        {
            // Arrange
            var basketRepositoryMock = new Mock<IBasketRepository>();
            var publishEndpointMock = new Mock<IPublishEndpoint>();


            // Act
            var handler = new CheckoutBasketCommandHandler(
                basketRepositoryMock.Object, publishEndpointMock.Object);
            var command = new CheckoutBasketCommand(new API.Dtos.BasketCheckoutDto());
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task It_Should_Return_TrueResult_If_BasketFoundInDatabase()
        {
            // Arrange
            var basketRepositoryMock = new Mock<IBasketRepository>();
            var publishEndpointMock = new Mock<IPublishEndpoint>();

            var shoppingCart = new API.Models.ShoppingCart();

            basketRepositoryMock.Setup(x => x.GetBasket(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(shoppingCart);

            // Act
            var handler = new CheckoutBasketCommandHandler(
                basketRepositoryMock.Object, publishEndpointMock.Object);
            var command = new CheckoutBasketCommand(new API.Dtos.BasketCheckoutDto());
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
        }
    }
}
