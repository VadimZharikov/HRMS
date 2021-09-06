using System.ComponentModel.DataAnnotations;

namespace InventoryDAL.Entities
{
    public class ItemEntity
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int EmployeeId { get; set; }
    }
}
