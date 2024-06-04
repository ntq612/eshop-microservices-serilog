using Basket.API.Basket.GetBasket;
using Basket.API.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Api.Unit.Tests.Handlers
{
    public class GetBasketQueryHandlerTests
    {
        [Fact]
        public void It_Should_Return_Basket()
        {
            // Arrange
            var basketRepositoryMock = new Mock<IBasketRepository>();

            // Act
            var query = new GetBasketQuery("testusername");
            var handler = new GetBasketQueryHandler(basketRepositoryMock.Object);
            var result = handler.Handle(query, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            
        }
    }
}
