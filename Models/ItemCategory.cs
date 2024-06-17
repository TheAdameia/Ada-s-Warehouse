using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdasWarehouse.Models;

public class ItemCategory
{
    public int ItemCategoryId { get; set; }
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [ForeignKey("ItemId")]
    public Item Item { get; set; }  // this is a navigation property
}