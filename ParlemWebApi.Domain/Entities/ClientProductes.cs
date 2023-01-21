using System.Collections.Generic;

namespace ParlemWebApi.Domain.Entities
{
    public class ClientProductes
    {
        public string customerId { get; set; }
        public List<Producte> Products { get; set; }
    }
}
