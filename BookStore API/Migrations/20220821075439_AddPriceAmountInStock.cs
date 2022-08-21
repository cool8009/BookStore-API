using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_API.Migrations
{
    public partial class AddPriceAmountInStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f26631d-a5c6-4631-867f-8dbbf9912319");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8289940-dfe6-43f7-9208-7a0bf5658b11");

            migrationBuilder.AddColumn<int>(
                name: "AmountInStock",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Books",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c55f3a1-307d-49f5-9e9e-3dff87e831b3", "b0a26358-fd42-45b1-968f-4b568ba69a09", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9659e03-e22d-4963-ade5-f23cebd5d308", "82cae3bc-bed8-4fbc-8402-3a1fe15c28aa", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c55f3a1-307d-49f5-9e9e-3dff87e831b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9659e03-e22d-4963-ade5-f23cebd5d308");

            migrationBuilder.DropColumn(
                name: "AmountInStock",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f26631d-a5c6-4631-867f-8dbbf9912319", "8da2f299-9555-4742-9f88-e48d6e9db078", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8289940-dfe6-43f7-9208-7a0bf5658b11", "da116bd8-cc17-4114-8615-0789770cef54", "User", "USER" });
        }
    }
}
