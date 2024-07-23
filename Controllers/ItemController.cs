using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public ItemController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Items.ToList());
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetByUser(int id)
    {
        return Ok(_dbContext.Items
        .Where(i => i.UserId == id)
        .ToList());
    }

    [HttpGet("single/{id}")]
    public IActionResult GetOneItem(int id)
    {
        return Ok(_dbContext.Items
        .Include(i => i.ItemCategory)
            .ThenInclude(ic => ic.Category)
        .SingleOrDefault(i => i.ItemId == id));
    }

    [HttpPost]
    //[Authorize]
    public IActionResult CreateItem(Item item)
    {

        //create the new item
        _dbContext.Items.Add(item);
        _dbContext.SaveChanges();

        return Created($"api/items/{item.ItemId}", item);
    }

    [HttpPut("{id}")]
    //[Authorize]
    public IActionResult EditItem(Item item)
    {
        Item itemToUpdate = _dbContext.Items
        .Include(i => i.ItemCategory)
        .SingleOrDefault(i => i.ItemId == item.ItemId);

        if (itemToUpdate == null)
        {
            return NotFound();
        }
        else if (item.UserId != itemToUpdate.UserId)
        {
            return BadRequest("Not the right user");
        }

        itemToUpdate.Description = item.Description;
        itemToUpdate.FloorId = item.FloorId;
        itemToUpdate.Weight = item.Weight;

        if (item.ItemCategory != null)
        {
            var existingIC = itemToUpdate.ItemCategory.ToList();
            var newCategories = item.ItemCategory.Select(ic => ic.CategoryId).ToList();

            foreach (var single in existingIC)
            {
                if (!newCategories.Contains(single.CategoryId))
                {
                    _dbContext.ItemCategories.Remove(single);
                }
            }

            foreach (var newCategoryId in newCategories)
            {
                if (!existingIC.Any(eic => eic.CategoryId == newCategoryId))
                {
                    _dbContext.ItemCategories.Add(new ItemCategory
                    {
                        ItemId = item.ItemId,
                        CategoryId = newCategoryId
                    });
                }
            }
        }

        _dbContext.SaveChanges();
        return NoContent();
    }

    // in all likelihood it will be more expedient to write a different endpoint for changing warehouses that only changes warehouse and floor ids

    [HttpPut("transfer/{id}")]
    // [Authorize]
    public IActionResult TransferWarehouse(Item item)
    {
        Item ItemToTransfer = _dbContext.Items.SingleOrDefault(i => i.ItemId == item.ItemId);

        if (ItemToTransfer == null)
        {
            return BadRequest();
        }

        ItemToTransfer.WarehouseId = item.WarehouseId;
        ItemToTransfer.FloorId = item.FloorId;

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    //[Authorize]
    public IActionResult DeleteItem(int id)
    {
        Item itemToDelete = _dbContext.Items.SingleOrDefault(i => i.ItemId == id);
        if (itemToDelete.ItemId == null)
        {
            return NotFound();
        }
        
        _dbContext.Items.Remove(itemToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }
}