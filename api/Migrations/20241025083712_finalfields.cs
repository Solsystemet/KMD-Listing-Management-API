using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class finalfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataCategories_CategoryList",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataSecurity_SecurityMeasures",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataTransfer_TransferInformation",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCategories_CategoryList",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataSecurity_SecurityMeasures",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataTransfer_TransferInformation",
                table: "DataProcessor30ListingDatas");
        }
    }
}
