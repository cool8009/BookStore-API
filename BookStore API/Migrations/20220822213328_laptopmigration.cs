using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore_API.Migrations
{
    public partial class laptopmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abb426b-544e-4ccc-b64e-7bd1e8925a5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81bcd8a9-eae0-4e8c-81a4-a3073ee57d6f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75c7b984-a065-47fb-b70c-07eb45efabd3", "68561ce0-4f20-4a58-b8c6-8d5b09c310cf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6478612-3ab0-4516-ad11-2d0dab972ee4", "28f0025d-f61b-4ad7-a9bd-1129ec4775fc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75c7b984-a065-47fb-b70c-07eb45efabd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6478612-3ab0-4516-ad11-2d0dab972ee4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5abb426b-544e-4ccc-b64e-7bd1e8925a5c", "09b27ec2-f493-4b5e-8d5c-83bf36fa3523", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81bcd8a9-eae0-4e8c-81a4-a3073ee57d6f", "45db83ce-91e5-41c2-ac13-4067ab8ce506", "Administrator", "ADMINISTRATOR" });
        }
    }
}
