using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using InventoryApi.Models;
using InventoryBLL.Interfaces;
using InventoryBLL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IItemService itemService;
        private IMapper _mapper;
        public ItemsController(IItemService serv, IMapper mapper)
        {
            itemService = serv;
            _mapper = mapper;
        }
        // GET: api/<ItemsController>
        [HttpGet]
        public async Task<List<ItemViewModel>> GetItems()
        {
            var items = await itemService.GetItems();
            return _mapper.Map<List<Item>, List<ItemViewModel>>(items);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public async Task<ItemViewModel> GetItem(int id)
        {
            var employee = _mapper.Map<Item, ItemViewModel>(await itemService.GetItem(id));
            return employee;
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<bool> Post(ItemViewModel item)
        {
            bool result = await itemService.AddItem(_mapper.Map<ItemViewModel, Item>(item));
            return result;
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, ItemViewModel item)
        {
            bool result = await itemService.PutItem(id, _mapper.Map<ItemViewModel, Item>(item));
            return result;
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            bool result = await itemService.DeleteItem(id);
            return result;
        }
    }
}
