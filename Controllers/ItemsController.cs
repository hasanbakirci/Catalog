using Microsoft.AspNetCore.Mvc;
using catalog.Repositories;
using catalog.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using catalog.Dtos;
using System.Threading.Tasks;

namespace catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase
    {
        private readonly IRepository repository;

        public ItemsController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            // var items = repository.GetItems().Select(item => new ItemDto{
            //     Id = item.Id,
            //     Name = item.Name,
            //     Price = item.Price,
            //     CreatedDate = item.CreatedDate,
            // });
            var items = (await repository.GetItemsAsync()).Select(item => item.AsDto());
            return items;
        }
        // /items/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item = await repository.GetItemAsync(id);
            if(item is null)
            {
                return NotFound("Liste bombooş");
            }
            return Ok(item.AsDto());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto createItemDto)
        {
            Item item = new Item(){
                Id = Guid.NewGuid(),
                Name = createItemDto.Name,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await repository.CreateItemAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id},item.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            Item updateItem = existingItem with
            {
                Name = updateItemDto.Name,
                Price = updateItemDto.Price
            };
            await repository.UpdateItemAsync(updateItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            await repository.DeleteteItemAsync(existingItem);
            return NoContent();
        }
    }
}