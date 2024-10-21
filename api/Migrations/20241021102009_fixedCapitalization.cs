using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class fixedCapitalization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dataProcessor30ListingDatas",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.RenameTable(
                name: "dataProcessor30ListingDatas",
                newName: "DataProcessor30ListingDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataProcessor30ListingDatas",
                table: "DataProcessor30ListingDatas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DataProcessor30ListingDatas",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.RenameTable(
                name: "DataProcessor30ListingDatas",
                newName: "dataProcessor30ListingDatas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dataProcessor30ListingDatas",
                table: "dataProcessor30ListingDatas",
                column: "Id");
        }
    }
}
