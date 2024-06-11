using AdasWarehouse.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
using AdasWarehouse.Models;

namespace AdasWarehouse.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class CategoryController : ControllerBase
// {
//     private AdasWarehouseDbContext _dbContext;

//     public CategoryController(AdasWarehouseDbContext context)
//     {
//         _dbContext = context;
//     }

//     [HttpGet]
//     [Authorize]
//     public IActionResult Get()
//     {
//         return Ok(_dbContext.Category
//         .ToList());
//     }
// }