using System;
using System.Collections.Generic;
using catalog.Entities;

namespace catalog.Repositories
{
    public interface IRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}