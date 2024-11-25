using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas");

            migrationBuilder.RenameColumn(
                name: "transferReason",
                table: "DataSubProcessor",
                newName: "TransferReason");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "DataSubProcessor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "directSubProcessor",
                table: "DataSubProcessor",
                newName: "DirectSubProcessor");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas");

            migrationBuilder.RenameColumn(
                name: "TransferReason",
                table: "DataSubProcessor",
                newName: "transferReason");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "DataSubProcessor",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DirectSubProcessor",
                table: "DataSubProcessor",
                newName: "directSubProcessor");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");
        }
    }
}
