using AdasWarehouse.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Models;
using AdasWarehouse.Models.DTOs;

namespace AdasWarehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public CategoryController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Categories.ToList());
    }

    [HttpGet("floor/{id}")]
    // [Authorize]
    public IActionResult GetFloorCategories(int id)
    {
        Floor floor = _dbContext.Floors
            .Include(f => f.Items)
                .ThenInclude(i => i.ItemCategory)
                    .ThenInclude(ic => ic.Category)
            .SingleOrDefault(f => f.FloorId == id);
        
        if (floor == null)
        {
            return NotFound();
        }

        List<CategoryDTO> categoryList = new List<CategoryDTO>();

        foreach (var item in floor.Items)
        {
            if (item.ItemCategory != null)
            {
                foreach (var itemCategory in item.ItemCategory)
                {
                    CategoryDTO taco = new CategoryDTO
                    {
                        CategoryId = itemCategory.Category.CategoryId,
                        Name = itemCategory.Category.Name
                    };
                    categoryList.Add(taco);
                }
            }
        }

        return Ok(categoryList);
    }
}