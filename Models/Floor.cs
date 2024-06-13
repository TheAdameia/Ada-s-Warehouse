using System.ComponentModel.DataAnnotations;

namespace AdasWarehouse.Models;

public class Floor
{
    [Key]
    public int FloorId { get; set; }
    public int MaxStorageWeight { get; set; }
    public List<Item> Items { get; set; }
    public int TotalWeight
    {
        get
        {
            return Items != null ? Items.Sum(i => i.Weight) : 0;
        }
    }
    public bool IsOverloaded
    {
        get
        {
            return TotalWeight > MaxStorageWeight;
        }
    }
    public int RemainingStorage
    {
        get
        {
            return MaxStorageWeight - TotalWeight;
        }
    }
}