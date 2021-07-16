using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using catalog.Entities;

namespace catalog.Repositories
{
    public interface IRepository
    {
        Task<Item> GetItemAsync(Guid id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteteItemAsync(Item item);
    }
}