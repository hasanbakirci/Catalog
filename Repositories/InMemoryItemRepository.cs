using System;
using System.Collections.Generic;
using System.Linq;
using catalog.Entities;
namespace catalog.Repositories
{
    public class InMemoryItemRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item{Id= Guid.NewGuid(), Name="Potion",Price = 9, CreatedDate = DateTimeOffset.Now},
            new Item{Id= Guid.NewGuid(), Name="Iron Sword",Price = 16, CreatedDate = DateTimeOffset.Now},
            new Item{Id= Guid.NewGuid(), Name="Bronze Shild",Price = 37, CreatedDate = DateTimeOffset.Now},
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }

}