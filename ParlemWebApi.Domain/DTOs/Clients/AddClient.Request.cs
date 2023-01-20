using Newtonsoft.Json;
using ParlemWebApi.Domain.Shared;

namespace ParlemWebApi.Domain.DTOs.Clients
{
    /*
     * {
         "_id" : 555555,
         "docType" : "nif",
         "docNum" : "11223344E",
         "email" : "it@parlem.com",
         "customerId" : "11111",
         "givenName" : "Enriqueta",
         "familyName1" : "Parlem",
         "phone" : "668668668",
        }
     */
    public class AddClientRequest
    {
        [JsonProperty("_id")]
        public int ID { get; set; }

        [JsonProperty("docType")]
        public DocTypeEnum DocType { get; set; }

        [JsonProperty("docNum")]
        public string DocNum { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("givenName")]
        public string GivenName { get; set; }

        [JsonProperty("familyName1")]
        public string FamilyName1 { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
