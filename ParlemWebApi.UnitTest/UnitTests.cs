using Moq;
using NUnit.Framework;
using ParlemApi.Infrastructure.Interfaces;
using ParlemWebApi.Domain.Interfaces;
using ParlemWebApi.Domain.Services;
using FluentAssertions;
using System.Collections.Generic;

namespace ParlemWebApi.UnitTest
{
    [TestFixture]
    public class UnitTests
    {
        #region Variables

        private IClientService _clientService;
        private Mock<IRepository> _clientRespository;
        private Mock<IRepository> _productRespository;

        #endregion

        #region Set up

        [SetUp]
        public void SetUp()
        {
            _clientRespository = new Mock<IRepository>();
            _productRespository = new Mock<IRepository>();

            // SetUp repository Mocks
            _productRespository.Setup(x => x.ListAsync(It.IsAny<string>()))
                .Returns(new List<string>() { "123456", "nameTest", "typeTest", "numeracioTerminalTest", "soldAttest", "5454458" });

            _clientService = new ClientService(_clientRespository.Object, _productRespository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _clientService = null;
        }

        #endregion

        #region Tests

        [TestCase(Description = "Test intended to check the client service for obtaining all the client products.")]
        public void ReturnAllProductsFromClient()
        {
            // Arrange
            int? customerId = 1;

            // Act
            var response = _clientService.GetAllClientProducts(customerId);

            // Assert
            response.Products.Should().NotBeEmpty();            
        }

        #endregion
    }
}
