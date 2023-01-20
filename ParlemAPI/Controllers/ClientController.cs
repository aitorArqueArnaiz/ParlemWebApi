using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParlemWebApi.Domain.DTOs.Clients;

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
        public ActionResult<AddClientRequest> AddItem([FromBody] AddClientResponse client)
        {
            return NotFound();
        }
    }
}
