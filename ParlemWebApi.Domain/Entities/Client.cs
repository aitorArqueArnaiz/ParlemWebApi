using ParlemWebApi.Domain.Base;
using ParlemWebApi.Domain.Shared;

namespace ParlemWebApi.Domain.Entities
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
    public class Client : BaseEntity
    {
        public string DocType { get; set; }
        public string DocNum { get; set; }
        public string Email { get; set; }
        public int CustomerId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName1 { get; set; }
        public string Phone { get; set; }
    }
}
