using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DataEditsnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataEdit_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEdit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataEdit",
                table: "DataEdit");

            migrationBuilder.RenameTable(
                name: "DataEdit",
                newName: "DataEditDatas");

            migrationBuilder.RenameIndex(
                name: "IX_DataEdit_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                newName: "IX_DataEditDatas_DataProcessor30ListingDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataEditDatas",
                table: "DataEditDatas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataEditDatas",
                table: "DataEditDatas");

            migrationBuilder.RenameTable(
                name: "DataEditDatas",
                newName: "DataEdit");

            migrationBuilder.RenameIndex(
                name: "IX_DataEditDatas_DataProcessor30ListingDataId",
                table: "DataEdit",
                newName: "IX_DataEdit_DataProcessor30ListingDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataEdit",
                table: "DataEdit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataEdit_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                table: "DataEdit",
                column: "DataProcessor30ListingDataId",
                principalTable: "DataProcessor30ListingDatas",
                principalColumn: "Id");
        }
    }
}
