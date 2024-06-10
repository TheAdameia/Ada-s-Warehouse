
namespace AdasWarehouse.Models;

public class Item
{
    public int ItemId { get; set; }
    public int FloorId { get; set; }
    public int Weight { get; set; }
    public int UserId { get; set; }
    public string Description { get; set; }
}