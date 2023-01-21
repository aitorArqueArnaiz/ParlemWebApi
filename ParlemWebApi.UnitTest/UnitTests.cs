using Moq;
using NUnit.Framework;
using ParlemApi.Infrastructure.Interfaces;
using ParlemWebApi.Domain.Interfaces;
using ParlemWebApi.Domain.Services;
using FluentAssertions;
using System.Collections.Generic;
using ParlemWebApi.Domain.Entities;

namespace ParlemWebApi.UnitTest
{
    [TestFixture]
    public class UnitTests
    {
        #region Variables

        private IClientService _clientService;
        private IProductService _productService;
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
                .Returns(new List<string>() { "3553525, 'string', 'Fresh', 543646, '20/12/2022', 123456" });

            _productRespository.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns("123456, nameTest, typeTest, numeracioTerminalTest, soldAttest, 5454458");

            _clientRespository.Setup(x => x.ListAsync(It.IsAny<string>()))
                .Returns(new List<string>() { "3553525, 'string', 'Fresh', 543646, '20/12/2022', 123456" });

            _clientRespository.Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns("123456, nameTest, typeTest, numeracioTerminalTest, soldAttest, 5454458");

            _clientService = new ClientService(_clientRespository.Object, _productRespository.Object);
            _productService = new ProductService(_productRespository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _clientService = null;
        }

        #endregion

        #region Tests

        [TestCase(Description = "Test intended to check the client service for obtaining all the client products.")]
        [Author("Aitor Arqué Arnaiz")]
        public void ReturnAllProductsFromClient()
        {
            // Arrange
            int? customerId = 1;

            // Act
            var response = _clientService.GetAllClientProducts(customerId);

            // Assert
            response.Products.Should().NotBeEmpty();
            response.Should().BeOfType(typeof(ClientProductes));
            response.Products.Should().HaveCount(1);
        }

        [TestCase(Description = "Test intended to check the client service for obtaining clients.")]
        [Author("Aitor Arqué Arnaiz")]
        public void ReturnAllClients()
        {
            // Arrange

            // Act
            var response = _clientService.GetAllClients();

            // Assert
            response.Should().NotBeEmpty();
            response.Should().BeOfType(typeof(List<Client>));
            response.Should().HaveCount(1);
        }

        [TestCase(Description = "Test intended to check the client service for obtaining client by Id.")]
        [Author("Aitor Arqué Arnaiz")]
        public void ReturnClientById()
        {
            // Arrange
            int? customerId = 1;

            // Act
            var response = _clientService.GetClient(customerId);

            // Assert
            response.Should().NotBeNull();
            response.Should().BeOfType(typeof(Client));
        }

        [TestCase(Description = "Test intended to check the client service for Add a new client.")]
        [Author("Aitor Arqué Arnaiz")]
        public void CreateNewClient()
        {
            // Arrange
            Client client = new Client()
            {
                CustomerId = 1,
                DocNum = "5",
                DocType = "Type2",
                Email = "test@mailinator.com",
                FamilyName1 = "TestName",
                GivenName = "TestGivenName",
                ID = 123456,
                Phone = "93458435"
            };

            // Act
            var response = _clientService.AddClientByAsync(client);

            // Assert
            response.Should().NotBeNull();
        }

        [TestCase(Description = "Test intended to check the client service for obtaining product by Id.")]
        [Author("Aitor Arqué Arnaiz")]
        public void ReturnProductById()
        {
            // Arrange
            int? productId = 1;

            // Act
            var response = _productService.GetProduct(productId);

            // Assert
            response.Should().BeOfType(typeof(Producte));
            response.Should().NotBeNull();
        }

        [TestCase(Description = "Test intended to check the client service for obtaining all products.")]
        [Author("Aitor Arqué Arnaiz")]
        public void ReturnAllProducts()
        {
            // Arrange

            // Act
            var response = _productService.GetAllProducts();

            // Assert
            response.Should().NotBeNull();
            response.Should().HaveCount(1);
            response.Should().BeOfType(typeof(List<Producte>));
        }

        [TestCase(Description = "Test intended to check the client service for add a new product.")]
        [Author("Aitor Arqué Arnaiz")]
        public void AddNewProduct()
        {
            // Arrange
            Producte producte = new Producte()
            {
                CustomerId = 1,
                ID = 123456,
                NumeracioTerminal = "95743867348",
                ProductName = "testName",
                ProductTypeName = "typeTestName",
                SoldAt = "19/8/2021"
            };

            // Act
            var response = _productService.AddProductByAsync(producte);

            // Assert
            response.Should().NotBeNull();
        }

        #endregion
    }
}
