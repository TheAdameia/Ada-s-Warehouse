using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdasWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class UserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "289e8352-58a3-4d2c-9016-f25f4bb0b5e9", "AQAAAAIAAYagAAAAEIRIekJ/f1GOGIX3uC2pk472HwT2fJIsDm7f2Biq1sEsOwI9gYl9cGv1whHI55hRVQ==", "b00eeec0-74fc-496a-abf3-1fe068cdb3a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f380cf4-a9d0-4a99-b3c5-6e99c4e331e9", "AQAAAAIAAYagAAAAEDm1n1jUwYViGlOpSPg1yA+4FiDRzfN76sZ8aQzClQxZyUWQQBfWrvKWUmBY1JfsAw==", "cbf4d858-17d9-48af-9e26-4fedf6571a62" });
        }
    }
}
