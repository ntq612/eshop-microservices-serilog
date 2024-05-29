using Basket.API.Basket.StoreBasket;
using Basket.API.Data;
using Discount.Grpc;
using MassTransit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Unit.Tests.Handlers
{
    public class StoreBasketCommandHandlerTests
    {
        [Fact]
        public void CanHandleStoreBasketCommandHandler()
        {
        //    // Arrange
        //    var basketRepositoryMock = new Mock<IBasketRepository>();
        //    var discountProtoService = new Mock<DiscountProtoService.DiscountProtoServiceClient>();

        //    // Act
        //    var handle = new StoreBasketCommandHandler(basketRepositoryMock.Object, discountProtoService);
        }
    }
}
