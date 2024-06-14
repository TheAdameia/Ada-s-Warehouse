using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;
using AdasWarehouse.Models.DTOs;

namespace AdasWarehouse.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FloorController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public FloorController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Floors
        .Include(f => f.Items)
        .ToList());
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetOneFloor(int id)
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

        OneFloorFullExpandDTO fullExpand = new OneFloorFullExpandDTO
        {
            FloorId = floor.FloorId,
            MaxStorageWeight = floor.MaxStorageWeight,
            Items = floor.Items.Select(i => new ItemDTO
            {
                ItemId = i.ItemId,
                FloorId = i.FloorId,
                Weight = i.Weight,
                UserId = i.UserId,
                Description = i.Description,
                ItemCategory = i.ItemCategory.Select(ic => new ItemCategoryDTO
                {
                    ItemCategoryId = ic.ItemCategoryId,
                    ItemId = ic.ItemId,
                    CategoryId = ic.CategoryId,
                    Category = new CategoryDTO
                    {
                        CategoryId = ic.Category.CategoryId,
                        Name = ic.Category.Name
                    }
                }).ToList(),
            }).ToList(),

        };

        return Ok(fullExpand);
    }
}