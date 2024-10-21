using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedOwnedTypesId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataController_Id",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Id",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_Id",
                table: "dataProcessor30ListingDatas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataController_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataProcessorRepresentative_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DataProcessor_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
