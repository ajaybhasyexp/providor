using Microsoft.EntityFrameworkCore.Migrations;

namespace Providor.Data.Migrations
{
    public partial class SeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "Id", "MeterType", "NumberOfRegisters", "OperatingMode" },
                values: new object[] { 1, 0, 2, 0 });

            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "Id", "MeterType", "NumberOfRegisters", "OperatingMode" },
                values: new object[] { 2, 1, 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Meters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Meters",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
