using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ItemCategoryController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public ItemCategoryController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.ItemCategories.ToList());
    }

    [HttpPost]
    //[Authorize]
    public IActionResult CreateItemCategory(ItemCategory itemCategory)
    {
        _dbContext.ItemCategories.Add(itemCategory);
        _dbContext.SaveChanges();
        return Created($"api/itemCategorys/{itemCategory.ItemCategoryId}", itemCategory);
    }

    [HttpDelete]
    //[Authorize]
    public IActionResult DeleteItemCategory(int id)
    {
        ItemCategory icToDelete = _dbContext.ItemCategories.SingleOrDefault(ic => ic.ItemCategoryId == id);
        if (icToDelete == null)
        {
            return NotFound();
        }

        _dbContext.ItemCategories.Remove(icToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
}