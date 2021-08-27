using Microsoft.EntityFrameworkCore.Migrations;

namespace Providor.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mpan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MpanIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeterType = table.Column<int>(type: "int", nullable: false),
                    OperatingMode = table.Column<int>(type: "int", nullable: false),
                    NumberOfRegisters = table.Column<int>(type: "int", nullable: false),
                    MeterPointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meters_MeterPoints_MeterPointId",
                        column: x => x.MeterPointId,
                        principalTable: "MeterPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MeterPoints",
                columns: new[] { "Id", "Mpan", "MpanIndicator" },
                values: new object[] { 1, "123456", "1" });

            migrationBuilder.InsertData(
                table: "MeterPoints",
                columns: new[] { "Id", "Mpan", "MpanIndicator" },
                values: new object[] { 2, "7891234", "1" });

            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "Id", "MeterPointId", "MeterType", "NumberOfRegisters", "OperatingMode" },
                values: new object[] { 1, 1, 0, 2, 0 });

            migrationBuilder.InsertData(
                table: "Meters",
                columns: new[] { "Id", "MeterPointId", "MeterType", "NumberOfRegisters", "OperatingMode" },
                values: new object[] { 2, 2, 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Meters_MeterPointId",
                table: "Meters",
                column: "MeterPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meters");

            migrationBuilder.DropTable(
                name: "MeterPoints");
        }
    }
}
