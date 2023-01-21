using ParlemWebApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParlemWebApi.Domain.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Method for adding a new product into the data base.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task AddProductByAsync(Producte product);

        /// <summary>
        /// Method for get a product with the given the Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Producte GetProduct(int? id);

        /// <summary>
        /// Method for getting all the existing products.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Producte> GetAllProducts();
    }
}
