using Microsoft.AspNetCore.Mvc;
using catalog.Repositories;
using catalog.Entities;
using System.Collections.Generic;
using System;
using System.Linq;
using catalog.Dtos;

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
        public IEnumerable<ItemDto> GetItems()
        {
            // var items = repository.GetItems().Select(item => new ItemDto{
            //     Id = item.Id,
            //     Name = item.Name,
            //     Price = item.Price,
            //     CreatedDate = item.CreatedDate,
            // });
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }
        // /items/id
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id).AsDto();
            if(item is null)
            {
                return NotFound("Liste bombooş");
            }
            return Ok(item);
        }
    }
}