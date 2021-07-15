using Microsoft.AspNetCore.Mvc;
using catalog.Repositories;
using catalog.Entities;
using System.Collections.Generic;
using System;

namespace catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase
    {
        private readonly InMemoryItemRepository repository;

        public ItemsController()
        {
            repository = new InMemoryItemRepository();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }
        // /items/id
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound("Liste bombooş");
            }
            return Ok(item);
        }
    }
}