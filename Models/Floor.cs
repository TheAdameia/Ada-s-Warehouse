namespace AdasWarehouse.Models;

public class Floor
{
    public int FloorId { get; set; }
    public int MaxStorageWeight { get; set; }
    public List<Item> Items { get; set; }
}