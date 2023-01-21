using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParlemWebApi.Domain.DTOs.Clients;
using ParlemWebApi.Domain.DTOs.Productes;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace parlemWebApi.Controllers
{
    [ApiController]
    [Route("api/parlem")]
    public class ProductController : ControllerBase
    {
        #region Class variables

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        #endregion

        #region Class constrctors

        public ProductController(ILogger<ProductController> logger,
                                IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        #endregion

        #region Controller Endpoints

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            try
            {
                var entitProducte = new Producte()
                {
                    CustomerId = request.CustomerId,
                    ID = request.ID,
                    NumeracioTerminal = request.NumeracioTerminal,
                    ProductName = request.ProductName,
                    ProductTypeName = request.ProductTypeName,
                    SoldAt = request.SoldAt
                };
                await _productService.AddProductByAsync(entitProducte);
                return Ok(new AddProductResponse { });
            }
            catch (Exception error)
            {
                throw new Exception($"Error adding product with id {null}. Exception message is : {error.Message}");
            }
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (id == null) return NotFound();
            try
            {
                var client = _productService.GetProduct(id);
                return Ok(new GetClientResponse() {  });
            }
            catch (Exception error)
            {
                throw new Exception($"Error getting product with id {null}. Exception message is : {error.Message}");
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var clients = _productService.GetAllProducts();
                return Ok(new GetAllClientsResponse() {  });
            }
            catch (Exception error)
            {
                throw new Exception($"Error getting all existing products with id {null}. Exception message is : {error.Message}");
            }
        }

        #endregion
    }
}
