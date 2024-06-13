using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

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
        return Ok(_dbContext.Floors
        .Include(f => f.Items)
            .ThenInclude(i => i.ItemCategory)
                .ThenInclude(ic => ic.Category)
        .SingleOrDefault(f => f.FloorId == id));
    }
}