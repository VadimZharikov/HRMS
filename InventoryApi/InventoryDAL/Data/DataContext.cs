using InventoryDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryDAL.Data
{
    class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ItemEntity> Items { get; set; }
    }
}
