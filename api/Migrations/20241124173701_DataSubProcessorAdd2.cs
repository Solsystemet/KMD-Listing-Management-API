using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSubProcessor",
                columns: table => new
                {
                    DataProcessor30ListingDataId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    directSubProcessor = table.Column<bool>(type: "bit", nullable: false),
                    transferReason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSubProcessor", x => new { x.DataProcessor30ListingDataId, x.Id });
                    table.ForeignKey(
                        name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                        column: x => x.DataProcessor30ListingDataId,
                        principalTable: "DataProcessor30ListingDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSubProcessor");
        }
    }
}
