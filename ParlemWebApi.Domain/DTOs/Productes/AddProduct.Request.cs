using Newtonsoft.Json;
using ParlemWebApi.Domain.Shared;

namespace ParlemWebApi.Domain.DTOs.Productes
{
    /*
     {
         "_id" : 1111111,
         "productName" : "FIBRA 1000 ADAMO",
         "productTypeName" : "ftth",
         "numeracioTerminal" : 933933933,
         "soldAt" : "2019-01-09 14:26:17",
         "customerId" : "11111",
        }
     */
    public class AddProductRequest
    {
        [JsonProperty("_id")]
        public int ID { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("productTypeName")]
        public ProductTypeNameEnum ProductTypeName { get; set; }

        [JsonProperty("numeracioTerminal")]
        public string NumeracioTerminal { get; set; }

        [JsonProperty("soldAt")]
        public string SoldAt { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }
    }
}
