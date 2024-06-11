using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdasWarehouse.Data;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;
[ApiController]
[Route("api/[controller]")]

public class ItemCategoryController : ControllerBase
{
    private AdasWarehouseDbContext _dbContext;

    public ItemCategoryController(AdasWarehouseDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.ItemCategories.ToList());
    }
}