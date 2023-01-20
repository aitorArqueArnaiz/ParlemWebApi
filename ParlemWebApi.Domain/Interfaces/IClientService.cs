using ParlemWebApi.Domain.Entities;
using System.Collections.Generic;

namespace ParlemWebApi.Domain.Interfaces
{
    public interface IClientService
    {
        /// <summary>
        /// Method for adding a new client into the data base.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        bool AddClient(Client client);

        /// <summary>
        /// Method for get a client with the given customer Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Client GetClient(int customerId);

        /// <summary>
        /// Method for getting all the existing clients.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Client> GetAllClients();
    }
}
