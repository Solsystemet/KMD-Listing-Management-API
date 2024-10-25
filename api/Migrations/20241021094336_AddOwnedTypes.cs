using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnedTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataController_Address",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DataController_CVR",
                table: "dataProcessor30ListingDatas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DataController_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DataController_Mail",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataController_Name",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataController_PhoneNo",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessorRepresentative_Address",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DataProcessorRepresentative_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DataProcessorRepresentative_Mail",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessorRepresentative_Name",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessorRepresentative_PhoneNo",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessor_Address",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DataProcessor_CVR",
                table: "dataProcessor30ListingDatas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "DataProcessor_Id",
                table: "dataProcessor30ListingDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DataProcessor_Mail",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessor_Name",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataProcessor_PhoneNo",
                table: "dataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataController_Address",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataController_CVR",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataController_Id",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataController_Mail",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataController_Name",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataController_PhoneNo",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Address",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Id",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Mail",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_Name",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessorRepresentative_PhoneNo",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_Address",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_CVR",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_Id",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_Mail",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_Name",
                table: "dataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataProcessor_PhoneNo",
                table: "dataProcessor30ListingDatas");
        }
    }
}
