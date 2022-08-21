using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_API.Migrations
{
    public partial class AddPriceAmountInStock2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c55f3a1-307d-49f5-9e9e-3dff87e831b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9659e03-e22d-4963-ade5-f23cebd5d308");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c8ee8538-0430-4db6-980f-f413ddf51981", "67f6f7ee-4ced-4b88-8eff-578598a60901", "User", "USER" },
                    { "ffdbe28d-710d-49d8-8419-15310a30d1f9", "4fa82dd9-2cc3-4493-9169-573d9753dce3", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 10, 50.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 10, 50.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 10, 50.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 10, 50.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 10, 50.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8ee8538-0430-4db6-980f-f413ddf51981");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffdbe28d-710d-49d8-8419-15310a30d1f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c55f3a1-307d-49f5-9e9e-3dff87e831b3", "b0a26358-fd42-45b1-968f-4b568ba69a09", "User", "USER" },
                    { "e9659e03-e22d-4963-ade5-f23cebd5d308", "82cae3bc-bed8-4fbc-8402-3a1fe15c28aa", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmountInStock", "Price" },
                values: new object[] { 0, 0.0 });
        }
    }
}
