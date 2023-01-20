using ParlemWebApi.Domain.Base;
using ParlemWebApi.Domain.Shared;

namespace ParlemWebApi.Domain.Entities
{
    /*
     * {
         "_id" : 1111111,
         "productName" : "FIBRA 1000 ADAMO",
         "productTypeName" : "ftth",
         "numeracioTerminal" : 933933933,
         "soldAt" : "2019-01-09 14:26:17",
         "customerId" : "11111",
        }
     */
    public class  Producte : BaseEntity
    {
        public string ProductName { get; set; }
        public ProductTypeNameEnum ProductTypeName { get; set; }
        public string NumeracioTerminal { get; set; }
        public string SoldAt { get; set; }
        public int CustomerId { get; set; }
    }
}
