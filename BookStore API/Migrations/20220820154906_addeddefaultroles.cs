using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_API.Migrations
{
    public partial class addeddefaultroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "303f2b64-168c-42f9-b9fb-5c0f2bb2cbb5", "baccb62b-8604-46a1-8e21-60b3694a73fb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "940fc91e-9a58-4c9c-831f-016d45eb2e79", "e4431f50-cdb3-44f1-8895-3ff0e70ca764", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "303f2b64-168c-42f9-b9fb-5c0f2bb2cbb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940fc91e-9a58-4c9c-831f-016d45eb2e79");
        }
    }
}
