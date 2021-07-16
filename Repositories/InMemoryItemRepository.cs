using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catalog.Entities;
namespace catalog.Repositories
{
    public class InMemoryItemRepository : IRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item{Id= Guid.NewGuid(), Name="Potion",Price = 9, CreatedDate = DateTimeOffset.Now},
            new Item{Id= Guid.NewGuid(), Name="Iron Sword",Price = 16, CreatedDate = DateTimeOffset.Now},
            new Item{Id= Guid.NewGuid(), Name="Bronze Shild",Price = 37, CreatedDate = DateTimeOffset.Now},
        };
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteteItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}