using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor");

            migrationBuilder.AlterColumn<int>(
                name: "DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DataSubProcessor_DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                column: "DataProcessor30ListingDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor");

            migrationBuilder.DropIndex(
                name: "IX_DataSubProcessor_DataProcessor30ListingDataId",
                table: "DataSubProcessor");

            migrationBuilder.AlterColumn<int>(
                name: "DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor",
                columns: new[] { "DataProcessor30ListingDataId", "Id" });
        }
    }
}
