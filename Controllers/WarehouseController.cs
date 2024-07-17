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
}