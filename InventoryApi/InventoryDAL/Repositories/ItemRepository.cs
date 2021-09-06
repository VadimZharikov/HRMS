using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryDAL.Data;
using InventoryDAL.Entities;
using InventoryDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryDAL.Repositories
{
    class ItemRepository : IItemRepository
    {
        private DataContext _context;
        public ItemRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ItemEntity> GetItem(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<List<ItemEntity>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<ItemEntity> AddItem(ItemEntity item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemEntity> UpdateItem(ItemEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<ItemEntity> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
