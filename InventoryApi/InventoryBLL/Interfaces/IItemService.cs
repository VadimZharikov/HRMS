using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryBLL.Models;

namespace InventoryBLL.Interfaces
{
    public interface IItemService
    {
        public Task<Item> GetItem(int id);
        public Task<List<Item>> GetItems();
        public Task<bool> AddItem(Item item);
        public Task<bool> PutItem(int id, Item item);
        public Task<bool> DeleteItem(int id);
    }
}
