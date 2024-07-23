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


    // I'm not sure if I'm going to need to update this any to handle multiple warehouses, considering this is just for the sake of exclusion logic on the frontend. Since there's no reason to do anything with it yet, I won't.
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

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Floor floor)
    {
        if (floor == null)
        {
            return BadRequest();
        }
        else if (floor.WarehouseId == 0)
        {
            return BadRequest("no warehouse specified");
        }

        _dbContext.Floors.Add(floor);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult Delete(int id)
    {
        Floor FloorToDelete = _dbContext.Floors.SingleOrDefault(f => f.FloorId == id);
        if (FloorToDelete == null)
        {
            return BadRequest();
        }

        if (FloorToDelete.Items != null)
        {
            return BadRequest("All items must be removed before floor can be deleted");
        }

        _dbContext.Floors.Remove(FloorToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }

    // I will write a PUT if I really have to, but really the only thing that would make sense to change would be the weight capacity.
}