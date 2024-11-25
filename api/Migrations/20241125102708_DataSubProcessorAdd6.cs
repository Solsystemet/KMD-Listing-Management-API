using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataSubProcessorAdd6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "DataSubProcessor",
                newName: "PhoneNo");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DataSubProcessor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "DataSubProcessor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "DataSubProcessor");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "DataSubProcessor");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "DataSubProcessor",
                newName: "Adress");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSubProcessor_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataSubProcessor",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
