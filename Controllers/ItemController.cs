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
        .SingleOrDefault(i => i.ItemId == id));
    }

    [HttpPost]
    //[Authorize]
    public IActionResult CreateItem(Item item)
    {

        //create the new item
        _dbContext.Items.Add(item);
        _dbContext.SaveChanges();

        //check if item categories is null
        //if not null, add each one to the database with a loop/map. - create a new ItemCategory record with the id from the array and the item id
        if (item.ItemCategory != null)
        {
            foreach (var taco in item.ItemCategory)
            {
                ItemCategory ic = new ItemCategory
                {
                    ItemId = item.ItemId,
                    CategoryId = taco.CategoryId
                };  // this can't be a forof because of supposed conversion issues
            }
        }

        return Created($"api/items/{item.ItemId}", item);
    }

    [HttpPut("{id}")]
    //[Authorize]
    public IActionResult EditItem(Item item)
    {
        Item itemToUpdate = _dbContext.Items.SingleOrDefault(i => i.ItemId == item.ItemId);
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

        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    //[Authorize]
    public IActionResult DeleteItem(int id)
    // ok. This works but it doesn't delete ItemCategory. Will have to fix that.
    // Will fix instead by implementing a soft delete.
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