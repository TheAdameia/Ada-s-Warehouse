using System.ComponentModel.DataAnnotations;
namespace AdasWarehouse.Models;

public class Warehouse
{
    public int WarehouseId { get; set; }
    [Required]
    public string Location { get; set; }
}