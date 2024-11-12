using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataEdit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldsEdited = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProcessor30ListingDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEdit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEdit_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                        column: x => x.DataProcessor30ListingDataId,
                        principalTable: "DataProcessor30ListingDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataEdit_DataProcessor30ListingDataId",
                table: "DataEdit",
                column: "DataProcessor30ListingDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEdit");
        }
    }
}
