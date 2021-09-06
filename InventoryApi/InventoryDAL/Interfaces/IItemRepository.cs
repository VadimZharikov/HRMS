using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDAL.Entities;

namespace InventoryDAL.Interfaces
{
    public interface IItemRepository
    {
        public Task<ItemEntity> GetItem(int id);
        public Task<List<ItemEntity>> GetItems();
        public Task<ItemEntity> AddItem(ItemEntity item);
        public Task<ItemEntity> UpdateItem(ItemEntity item);
        public Task<ItemEntity> DeleteItem(int id);

    }
}
