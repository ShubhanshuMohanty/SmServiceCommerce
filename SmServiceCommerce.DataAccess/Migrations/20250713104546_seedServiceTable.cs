using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmServiceCommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedServiceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "Id", "ServiceName" },
                values: new object[,]
                {
                    { 1, "Plumber" },
                    { 2, "Electrician" },
                    { 3, "Carpenter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
