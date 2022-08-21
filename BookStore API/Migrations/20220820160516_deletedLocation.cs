using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_API.Migrations
{
    public partial class deletedLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "303f2b64-168c-42f9-b9fb-5c0f2bb2cbb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940fc91e-9a58-4c9c-831f-016d45eb2e79");

            migrationBuilder.DropColumn(
                name: "HomeLatitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomeLongitude",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f26631d-a5c6-4631-867f-8dbbf9912319", "8da2f299-9555-4742-9f88-e48d6e9db078", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8289940-dfe6-43f7-9208-7a0bf5658b11", "da116bd8-cc17-4114-8615-0789770cef54", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f26631d-a5c6-4631-867f-8dbbf9912319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8289940-dfe6-43f7-9208-7a0bf5658b11");

            migrationBuilder.AddColumn<float>(
                name: "HomeLatitude",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "HomeLongitude",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "303f2b64-168c-42f9-b9fb-5c0f2bb2cbb5", "baccb62b-8604-46a1-8e21-60b3694a73fb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "940fc91e-9a58-4c9c-831f-016d45eb2e79", "e4431f50-cdb3-44f1-8895-3ff0e70ca764", "Administrator", "ADMINISTRATOR" });
        }
    }
}
