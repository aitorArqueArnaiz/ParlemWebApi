using ParlemApi.Infrastructure.Interfaces;
using ParlemWebApi.Domain.Entities;
using ParlemWebApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParlemWebApi.Domain.Services
{
    public sealed class ProductService : IProductService
    {
        #region Class variables

        private readonly IRepository _producteRepository;

        #endregion

        #region Constructor

        public ProductService(IRepository producteRepository)
        {
            _producteRepository = producteRepository;
        }

        #endregion

        #region Main Methods

        public async Task AddProductByAsync(Producte producte)
        {
            await _producteRepository.AddAsync(CreateAddProducteDBRequest(producte));
        }

        public IEnumerable<Producte> GetAllProducts()
        {
            List<Producte> producteEntities = new List<Producte>() { };
            var clients = _producteRepository.ListAsync(GetAllProductsSQLQueryString());

            foreach (var e in clients)
            {
                var producteClean = e.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var producteEntity = CreateProducteEntity(producteClean);
                producteEntities.Add(producteEntity);
            }

            return producteEntities;
        }

        public Producte GetProduct(int? customerId)
        {
            var producte = _producteRepository.GetAsync(CreateGetClientDBRequest(customerId));
            var producteData = producte == null ? null : producte.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return CreateProducteEntity(producteData);
        }

        #endregion

        #region Private Methods

        private string CreateAddProducteDBRequest(Producte entityProducte)
        {
            return string.Format(string.Concat("INSERT INTO [Parlem].[dbo].[Producte]",
                "([_id],[productName],[productTypeName], [numeracioTerminal], [soldAt], [customerId])",
                "VALUES ({0}, '{1}', '{2}', {3}, '{4}', {5})"), entityProducte.ID, entityProducte.ProductName, entityProducte.ProductTypeName,
                entityProducte.NumeracioTerminal, entityProducte.SoldAt, entityProducte.CustomerId);
        }

        /// <summary>This method creates the SQl query to get corresponding customerId product.</summary>
        /// <returns>SQL query for gettting a client row.</returns>
        private string CreateGetClientDBRequest(int? id)
        {
            return "SELECT * FROM [Parlem].[dbo].[Producte] WHERE _id = " + id;
        }

        /// <summary>This method creates the SQl query to get all existing products.</summary>
        /// <returns>SQL query for getting all client rows.</returns>
        private string GetAllProductsSQLQueryString()
        {
            return "SELECT * FROM [Parlem].[dbo].[Producte]";
        }

        private Producte CreateProducteEntity(List<string> producteDB)
        {
            if (producteDB == null || producteDB.Count != 6)
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
