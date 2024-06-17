
using System.ComponentModel.DataAnnotations;

namespace AdasWarehouse.Models.DTOs;

public class ItemDTO
{
    [Key]
    public int ItemId { get; set; }
    public int FloorId { get; set; }
    public int Weight { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
    public List<ItemCategoryDTO>? ItemCategory { get; set; }
}