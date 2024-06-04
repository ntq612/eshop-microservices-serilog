using Basket.API.Basket.StoreBasket;
using Basket.API.Data;
using Basket.API.Models;
using Discount.Grpc;
using Grpc.Core;
using Moq;
using System.Reflection.Metadata;
using static Discount.Grpc.DiscountProtoService;

namespace Basket.Api.Unit.Tests.Handlers
{
    public class StoreBasketCommandHandlerTests
    {
        [Fact]
        public void It_Should_Return_UserName()
        {
            // Arrange
            var basketRepositoryMock = new Mock<IBasketRepository>();
            var discountProtoService = new Mock<DiscountProtoServiceClient>();
            var cart = new ShoppingCart
            {
                UserName = "testuser",
                Items =
                {
                    new ShoppingCartItem { ProductName = "Product 1", Price = 10 },
                    new ShoppingCartItem { ProductName = "Product 2", Price = 20 }
                }
            };
            // Setup Discount Grpc 

            // Act
            var handler = new StoreBasketCommandHandler(basketRepositoryMock.Object, discountProtoService.Object);
            var command = new StoreBasketCommand(cart);
            var result = handler.Handle(command, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Result.UserName);

        }

    }
}
