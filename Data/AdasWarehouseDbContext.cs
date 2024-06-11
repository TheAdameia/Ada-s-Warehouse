using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AdasWarehouse.Models;
using Microsoft.AspNetCore.Identity;

namespace AdasWarehouse.Data;
public class AdasWarehouseDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<UserProfile> UserProfiles { get; set; }

    public AdasWarehouseDbContext(DbContextOptions<AdasWarehouseDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category
            {
                CategoryId = 1,
                Name = "Class 1 - living thing",
            },
            new Category
            {
                CategoryId = 2,
                Name = "Class 2 - highly flammable",
            },
            new Category
            {
                CategoryId = 3,
                Name = "Class 3",
            },
            new Category
            {
                CategoryId = 4,
                Name = "Class 4",
            },
            new Category
            {
                CategoryId = 5,
                Name = "Class 5 - prone to spontaneous combustion",
            },
            new Category
            {
                CategoryId = 6,
                Name = "Class 6 - radioactive",
            }
        });

        modelBuilder.Entity<Exclusion>().HasData(new Exclusion[]
        {
            new Exclusion
            {
                ExclusionId = 1,
                CategoryId1 = 1,
                CategoryId2 = 6,
                SafeToPlace = false
            },
            new Exclusion
            {
                ExclusionId = 2,
                CategoryId1 = 2,
                CategoryId2 = 5,
                SafeToPlace = false
            }
        });
        
        modelBuilder.Entity<Floor>().HasData(new Floor[]
        {
            new Floor
            {
                FloorId = 1,
                MaxStorageWeight = 50000
            },
            new Floor
            {
                FloorId = 2,
                MaxStorageWeight = 35000
            },
            new Floor
            {
                FloorId = 3,
                MaxStorageWeight = 20000
            },
            new Floor
            {
                FloorId = 4,
                MaxStorageWeight = 15000
            },
            new Floor
            {
                FloorId = 5,
                MaxStorageWeight = 10000
            }
        });

        modelBuilder.Entity<Item>().HasData(new Item[]
        {
            new Item
            {
                ItemId = 1,
                FloorId = 1,
                Weight = 500,
                UserId = 1,
                Description = "Old tax paperwork"
            },
            new Item
            {
                ItemId = 2,
                FloorId = 3,
                Weight = 10000,
                UserId = 1,
                Description = "Acetone"
            },
            new Item
            {
                ItemId = 3,
                FloorId = 2,
                Weight = 15000,
                UserId = 1,
                Description = "Train engine"
            },
            new Item
            {
                ItemId = 4,
                FloorId = 1,
                Weight = 25000,
                UserId = 1,
                Description = "Giant bucket of sand"
            },
            new Item
            {
                ItemId = 5,
                FloorId = 5,
                Weight = 3505,
                UserId = 1,
                Description = "An old car"
            }
        });

        modelBuilder.Entity<ItemCategory>().HasData(new ItemCategory[]
        {
            new ItemCategory
            {
                ItemCategoryId = 1,
                ItemId = 2,
                CategoryId = 2
            },
            new ItemCategory
            {
                ItemCategoryId = 2,
                ItemId = 1,
                CategoryId = 5
            }
        });

    }
}