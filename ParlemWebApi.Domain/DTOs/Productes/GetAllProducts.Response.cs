using ParlemWebApi.Domain.Entities;
using System.Collections.Generic;

namespace ParlemWebApi.Domain.DTOs.Productes
{
    public class GetAllProductsResponse
    {
        public IEnumerable<Producte> Products { get; set; }
    }
}
