using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParlemWebApi.Domain.DTOs.Clients;
using System;

namespace parlemWebApi.Controllers
{
    [ApiController]
    [Route("api/parlem")]
    public class ClientController : ControllerBase
    {
        #region Class variables

        private readonly ILogger<ClientController> _logger;

        #endregion

        #region Class constrctors

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        #endregion

        [HttpPost]
        public ActionResult<AddClientRequest> AddProduct([FromBody] AddClientResponse client)
        {
            try
            {
                return Ok();
            }
            catch(Exception error)
            {
                throw new Exception($"Error adding product with id {null}");
            }
        }
    }
}
