
using System.ComponentModel.DataAnnotations;

namespace AdasWarehouse.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    public int FloorId { get; set; }
    public int Weight { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public List<ItemCategory>? ItemCategory { get; set; }
}