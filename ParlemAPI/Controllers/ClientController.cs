﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParlemWebApi.Domain.DTOs.Clients;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using System;

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
        [Route("AddProduct")]
        public ActionResult<AddClientResponse> AddProduct([FromBody] AddClientRequest client)
        {
            try
            {
                var entitClient = new Client()
                {
                    CustomerId = client.CustomerId,
                    DocNum = client.DocNum,
                    DocType = client.DocType,
                    Email = client.Email,
                    FamilyName1 = client.FamilyName1,
                    GivenName = client.GivenName,
                    ID = client.ID,
                    Phone = client.Phone
                };
                var response = _clientService.AddClientByAsync(entitClient);
                return Ok(response);
            }
            catch (Exception error)
            {
                throw new Exception($"Error adding product with id {null}. Exception message is : {error.Message}");
            }
        }

        #endregion
    }
}
