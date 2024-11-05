using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSecurity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataSecurityAdvisor_Address",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataSecurityAdvisor_Mail",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataSecurityAdvisor_Name",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DataSecurityAdvisor_PhoneNo",
                table: "DataProcessor30ListingDatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSecurityAdvisor_Address",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataSecurityAdvisor_Mail",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataSecurityAdvisor_Name",
                table: "DataProcessor30ListingDatas");

            migrationBuilder.DropColumn(
                name: "DataSecurityAdvisor_PhoneNo",
                table: "DataProcessor30ListingDatas");
        }
    }
}
