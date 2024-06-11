namespace AdasWarehouse.Models;

public class Exclusion
{
    public int ExclusionId { get; set; }
    public int CategoryId1 { get; set; }
    public int CategoryId2 { get; set; }
    public bool SafeToPlace { get; set; }
}