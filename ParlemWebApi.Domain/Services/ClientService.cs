using ParlemApi.Infrastructure.Interfaces;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParlemWebApi.Domain.Services
{
    public sealed class ClientService : IClientService
    {
        #region Class variables

        private readonly IRepository _clientRepository;
        private readonly IRepository _productRepository;

        private const int ClientNumberDBRegisters = 8;
        private const int ProductNumberDBRegisters = 6;

        #endregion

        #region Constructor

        public ClientService(IRepository clientRepository, IRepository productRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region Main Methods

        public async Task AddClientByAsync(Client client)
        {
            await _clientRepository.AddAsync(CreateAddClientDBRequest(client));
        }

        public IEnumerable<Client> GetAllClients()
        {
            List<Client> clientEntities = new List<Client>() { };
            var clients = _clientRepository.ListAsync(GetAllClientsSQLQueryString());

            foreach (var e in clients)
            {
                var clientClean = e.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var clientEntity = CreateClientEntity(clientClean);
                clientEntities.Add(clientEntity);
            }

            return clientEntities;
        }

        public Client GetClient(int? customerId)
        {
            var client = _clientRepository.GetAsync(CreateGetClientDBRequest(customerId));
            var clientData = client == null ? null : client.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return CreateClientEntity(clientData);
        }

        public ClientProductes GetAllClientProducts(int? customerId)
        {
            var clientProductEntities = new ClientProductes();
            clientProductEntities.Products = new List<Producte>() { };
            clientProductEntities.customerId = customerId.ToString();
            var clientProducts = _productRepository.ListAsync(GetAllClientProductsSQLQueryString(customerId));

            foreach (var e in clientProducts)
            {
                var clientProductsClean = e.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var clientProductEntity = CreateClientProductEntity(clientProductsClean);
                clientProductEntities.Products.Add(clientProductEntity);
            }

            return clientProductEntities;
        }

        #endregion

        #region Private Methods

        private string CreateAddClientDBRequest(Client entityClient)
        {
            return string.Format(string.Concat("INSERT INTO [Parlem].[dbo].[Client]",
                "([_id],[docType],[docNum], [email], [customerId], [givenName], [familyName1], [phone])",
                "VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}')"), entityClient.ID, entityClient.DocType, entityClient.DocNum,
                entityClient.Email, entityClient.CustomerId, entityClient.GivenName, entityClient.FamilyName1, entityClient.Phone);
        }

        /// <summary>This method creates the SQl query to get corresponding customerId product.</summary>
        /// <returns>SQL query for gettting a client row.</returns>
        private string CreateGetClientDBRequest(int? id)
        {
            return "SELECT * FROM [Parlem].[dbo].[Client] WHERE customerId = " + id;
        }

        /// <summary>This method creates the SQl query to get corresponding customerId product.</summary>
        /// <returns>SQL query for gettting a client row.</returns>
        private string GetAllClientProductsSQLQueryString(int? id)
        {
            return "SELECT [Parlem].[dbo].[Producte]._id, [Parlem].[dbo].[Producte].productName, [Parlem].[dbo].[Producte].productTypeName, [Parlem].[dbo].[Producte].numeracioTerminal, [Parlem].[dbo].[Producte].soldAt, [Parlem].[dbo].[Producte].customerId FROM [Parlem].[dbo].[Producte] INNER JOIN [Parlem].[dbo].[Client] ON [Parlem].[dbo].[Producte].[customerId] = [Parlem].[dbo].[Client].[customerId] WHERE [Parlem].[dbo].[Client].[customerId] = " + id;

        }

        /// <summary>This method creates the SQl query to get all existing products.</summary>
        /// <returns>SQL query for getting all client rows.</returns>
        private string GetAllClientsSQLQueryString()
        {
            return "SELECT * FROM [Parlem].[dbo].[Client]";
        }

        private Client CreateClientEntity(List<string> clientDb)
        {
            if (clientDb == null || clientDb.Count != ClientNumberDBRegisters)
            {
                return new Client();
            }
            return new Client()
            {
                ID = int.Parse(clientDb[0]),
                DocType = clientDb[1].Replace("'", string.Empty).Trim(),
                DocNum = clientDb[2].Replace("'", string.Empty).Trim(),
                Email = clientDb[3].Replace("'", string.Empty).Trim(),
                CustomerId = int.Parse(clientDb[4]),
                GivenName = clientDb[5].Replace("'", string.Empty).Trim(),
                FamilyName1 = clientDb[6].Replace("'", string.Empty).Trim(),
                Phone = clientDb[7].Replace("'", string.Empty).Trim()
            };
        }

        private Producte CreateClientProductEntity(List<string> producteDB)
        {
            if (producteDB == null || producteDB.Count != ProductNumberDBRegisters)
            {
                return new Producte();
            }
            return new Producte()
            {
                ID = int.Parse(producteDB[0]),
                ProductName = producteDB[1].Replace("'", string.Empty).Trim(),
                ProductTypeName = producteDB[2].Replace("'", string.Empty).Trim(),
                NumeracioTerminal = producteDB[3].Replace("'", string.Empty).Trim(),
                SoldAt = producteDB[4].Replace("'", string.Empty).Trim(),
                CustomerId = int.Parse(producteDB[5])
            };
        }

        #endregion
    }
}
