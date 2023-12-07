using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ecommerceApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fd7d421-b846-4d73-8cc2-4f15c3b1f5d3", null, "Admin", "ADMIN" },
                    { "59b47134-81f3-4a30-b5cb-058afc837084", null, "user", "USER" },
                    { "86122545-8c35-435d-8f5b-5bccaab5e859", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fd7d421-b846-4d73-8cc2-4f15c3b1f5d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59b47134-81f3-4a30-b5cb-058afc837084");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86122545-8c35-435d-8f5b-5bccaab5e859");
        }
    }
}
