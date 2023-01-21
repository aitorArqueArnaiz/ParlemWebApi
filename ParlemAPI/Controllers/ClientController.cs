using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParlemWebApi.Domain.DTOs.Clients;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using ParlemWebApi.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace parlemWebApi.Controllers
{
    [ApiController]
    [Route("api/parlem")]
    public class ClientController : ControllerBase
    {
        #region Class variables

        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _clientService;

        #endregion

        #region Class constrctors

        public ClientController(ILogger<ClientController> logger,
                                IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        #endregion

        #region Controller Endpoints

        [HttpPost]
        [Route("AddClient")]
        public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            try
            {
                var entitClient = new Client()
                {
                    CustomerId = request.CustomerId,
                    DocNum = request.DocNum,
                    DocType = Enum.GetName(typeof(DocTypeEnum) ,request.DocType),
                    Email = request.Email,
                    FamilyName1 = request.FamilyName1,
                    GivenName = request.GivenName,
                    ID = request.ID,
                    Phone = request.Phone
                };
                await _clientService.AddClientByAsync(entitClient);
                return Ok(new AddClientResponse { IsValid = true, CustomerId = entitClient.CustomerId });
            }
            catch (Exception error)
            {
                throw new Exception($"Error adding product with id {null}. Exception message is : {error.Message}");
            }
        }

        [HttpGet]
        [Route("GetClient")]
        public async Task<IActionResult> GetClient(int id)
        {
            if (id == null) return NotFound();
            try
            {
                var client = _clientService.GetClient(id);
                return Ok(new GetClientResponse() { Client = client });
            }
            catch (Exception error)
            {
                throw new Exception($"Error adding product with id {null}. Exception message is : {error.Message}");
            }
        }

        #endregion
    }
}
