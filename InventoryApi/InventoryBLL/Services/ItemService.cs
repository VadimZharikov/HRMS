using InventoryBLL.Interfaces;
using InventoryBLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InventoryDAL.Entities;
using Microsoft.Extensions.Logging;
using InventoryDAL.Interfaces;

namespace InventoryBLL.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository item;
        private IMapper _mapper;
        ILogger<ItemService> _logger;

        public ItemService(IItemRepository repo, ILogger<ItemService> logger, IMapper mapper)
        {
            item = repo;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> AddItem(Item item)
        {
            var result = await this.item.AddItem(_mapper.Map<Item, ItemEntity>(item));
            if (result.ItemId > 0)
            {
                _logger.LogInformation($"Item {result.ItemId} - {result.ItemName} was added");
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteItem(int id)
        {
            var result = await this.item.DeleteItem(id);
            if (result.ItemId > 0)
            {
                _logger.LogInformation($"Item {result.ItemId} - {result.ItemName} was deleted");
                return true;
            }
            return false;
        }

        public async Task<Item> GetItem(int id)
        {
            Item newItem = _mapper.Map<ItemEntity, Item>(await item.GetItem(id));
            return newItem;
        }

        public async Task<List<Item>> GetItems()
        {
            List<Item> items = _mapper.Map<List<ItemEntity>, List<Item>>(await item.GetItems());
            return items;
        }

        public async Task<bool> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return false;
            }

            var result = await this.item.UpdateItem(_mapper.Map<Item, ItemEntity>(item));
            if (result.ItemId > 0)
            {
                _logger.LogInformation($"Item {result.ItemId} - {result.ItemName} was updated");
                return true;
            }
            return false;
        }
    }
}
