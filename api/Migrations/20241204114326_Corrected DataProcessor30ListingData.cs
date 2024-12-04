using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedDataProcessor30ListingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "DataSubProcessors");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "DataSubProcessors");

            migrationBuilder.AddColumn<string>(
                name: "DataControllerRepresentative_Address",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataControllerRepresentative_Mail",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataControllerRepresentative_Name",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataControllerRepresentative_PhoneNo",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataControllerRepresentative_Role",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessorRepresentative_Role",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataControllerRepresentative_Address",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataControllerRepresentative_Mail",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataControllerRepresentative_Name",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataControllerRepresentative_PhoneNo",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataControllerRepresentative_Role",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Role",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "DataSubProcessors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "DataSubProcessors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
