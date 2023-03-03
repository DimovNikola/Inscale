using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class seedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 1, "Resource X", 100 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 2, "Resource Y", 200 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[] { 3, "Resource Z", 70 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
