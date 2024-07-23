using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public WarehouseController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.Warehouses
        .ToList());
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Warehouse warehouse)
    {
        _dbContext.Warehouses.Add(warehouse);
        _dbContext.SaveChanges();
        return Created($"api/warehouse/{warehouse.WarehouseId}", warehouse);
    }

    [HttpDelete]
    // [Authorize]
    public IActionResult Delete(int id)
    {
        Warehouse WarehouseToDelete = _dbContext.Warehouses.SingleOrDefault(w => w.WarehouseId == id);
        if (WarehouseToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Warehouses.Remove(WarehouseToDelete);
        _dbContext.SaveChanges();
        return NoContent();
    }

    // I'm not sure what I would want to modify with a PUT, so I'm not going to write one until it is called for.   
}