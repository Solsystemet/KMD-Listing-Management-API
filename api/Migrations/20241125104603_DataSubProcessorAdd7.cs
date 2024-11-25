using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor");

            migrationBuilder.RenameTable(
                name: "DataSubProcessor",
                newName: "DataSubProcessors");

            migrationBuilder.RenameIndex(
                name: "IX_DataSubProcessor_DataProcessor30ListingDataId",
                table: "DataSubProcessors",
                newName: "IX_DataSubProcessors_DataProcessor30ListingDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataSubProcessors",
                table: "DataSubProcessors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSubProcessors_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessors",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataSubProcessors_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataSubProcessors",
                table: "DataSubProcessors");

            migrationBuilder.RenameTable(
                name: "DataSubProcessors",
                newName: "DataSubProcessor");

            migrationBuilder.RenameIndex(
                name: "IX_DataSubProcessors_DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                newName: "IX_DataSubProcessor_DataProcessor30ListingDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataSubProcessor",
                table: "DataSubProcessor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");
        }
    }
}
