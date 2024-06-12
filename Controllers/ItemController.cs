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
    public IActionResult ToggleItem(int id, int? newFloorId)
    // ok. PSQL/EFC is too smart to let me reassign this to a nonexistent floor. I will have to nuke the database and start over, adding a key to Items for activity. Or I could just do a simpler delete? Decisions.
    {
        Item itemToToggle = _dbContext.Items.SingleOrDefault(i => i.ItemId == id);
        if (itemToToggle.ItemId == null)
        {
            return NotFound();
        }
        else if (id != itemToToggle.ItemId)
        {
            return BadRequest();
        }

        if (itemToToggle.FloorId != 0)
        {
            itemToToggle.FloorId = 0;
            _dbContext.SaveChanges();
            return NoContent();
        }
        else if (newFloorId != null)
        {
            itemToToggle.FloorId = (int)newFloorId;
            _dbContext.SaveChanges();
            return NoContent();
        }

        return BadRequest("No new floorId entered");
    }
}