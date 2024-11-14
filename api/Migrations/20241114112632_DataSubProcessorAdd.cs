using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataSubProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    directSubProcessor = table.Column<bool>(type: "bit", nullable: false),
                    transferReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor30ListingDataId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSubProcessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSubProcessors_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                        column: x => x.DataProcessor30ListingDataId,
                        principalTable: "DataProcessor30ListingDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSubProcessors_DataProcessor30ListingDataId",
                table: "DataSubProcessors",
                column: "DataProcessor30ListingDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataSubProcessors");
        }
    }
}
