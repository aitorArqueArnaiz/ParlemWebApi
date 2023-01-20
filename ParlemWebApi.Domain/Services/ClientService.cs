using ParlemApi.Infrastructure.Interfaces;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParlemWebApi.Domain.Services
{
    public sealed class ClientService : IClientService
    {
        #region Class variables

        private readonly IRepository _clientrepository;

        #endregion

        #region Constructor

        public ClientService(IRepository clientRepository)
        {
            _clientrepository = clientRepository;
        }

        #endregion

        #region Main Methods

        public async Task AddClientByAsync(Client client)
        {
            await _clientrepository.AddAsync(createClientDBRequest(client));
        }

        public IEnumerable<Client> GetAllClients()
        {
            throw new System.NotImplementedException();
        }

        public Client GetClient(int customerId)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Private Methods

        private string createClientDBRequest(Client entityClient)
        {
            return string.Format(string.Concat("INSERT INTO [Parlem].[dbo].[Client]",
                "([_id],[docType],[docNum], [email], [customerId], [givenName], [familyName1], [phone])",
                "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')"), entityClient.ID, entityClient.DocType, entityClient.DocNum,
                entityClient.Email, entityClient.CustomerId, entityClient.GivenName, entityClient.FamilyName1, entityClient.Phone);
        }

        #endregion
    }
}
