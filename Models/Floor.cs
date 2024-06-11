using System.ComponentModel.DataAnnotations;

namespace AdasWarehouse.Models;

public class Floor
{
    [Key]
    public int FloorId { get; set; }
    public int MaxStorageWeight { get; set; }
    public List<Item> Items { get; set; }
}