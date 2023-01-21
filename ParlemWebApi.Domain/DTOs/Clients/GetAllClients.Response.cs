using ParlemWebApi.Domain.Entities;
using System.Collections.Generic;

namespace ParlemWebApi.Domain.DTOs.Clients
{
    public class GetAllClientsResponse
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
