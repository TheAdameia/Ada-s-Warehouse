namespace AdasWarehouse.Models.DTOs;

public class ItemCategoryDTO
{
    public int ItemCategoryId { get; set; }
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public CategoryDTO Category { get; set; }
}