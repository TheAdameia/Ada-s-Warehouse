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
        _dbContext.Items.Add(item);
        _dbContext.SaveChanges();
        return Created($"api/items/{item.ItemId}", item);
    }

    [HttpPut("{id}")]
    //[Authorize]
    public IActionResult EditItem(Item item, int id)
    {
        Item itemToUpdate = _dbContext.Items.SingleOrDefault(i => i.ItemId == id);
        if (itemToUpdate == null)
        {
            return NotFound();
        }
        else if (id != itemToUpdate.ItemId)
        {
            return BadRequest();
        }

        itemToUpdate.Description = item.Description;
        itemToUpdate.FloorId = item.FloorId;

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