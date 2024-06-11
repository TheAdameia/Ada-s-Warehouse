using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;

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
        .Where(i => i.ItemId == id)
        .ToList());
    }
}