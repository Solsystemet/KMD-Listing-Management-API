using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataProcessor30ListingDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataController_CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataController_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataController_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataController_PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataController_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor_CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor_PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessorRepresentative_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessorRepresentative_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessorRepresentative_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessorRepresentative_PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessorRepresentative_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataControllerRepresentative_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataControllerRepresentative_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataControllerRepresentative_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataControllerRepresentative_PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataControllerRepresentative_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSecurityAdvisor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSecurityAdvisor_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSecurityAdvisor_PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSecurityAdvisor_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCategories_CategoryList = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataTransfer_TransferInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSecurity_SecurityMeasures = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataProcessor30ListingDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataEditDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EditType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldsEdited = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataProcessor30ListingDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEditDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataEditDatas_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                        column: x => x.DataProcessor30ListingDataId,
                        principalTable: "DataProcessor30ListingDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataSubProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectSubProcessor = table.Column<bool>(type: "bit", nullable: false),
                    TransferReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataProcessor30ListingDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSubProcessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSubProcessors_DataProcessor30ListingDatas_DataProcessor30ListingDataId",
                        column: x => x.DataProcessor30ListingDataId,
                        principalTable: "DataProcessor30ListingDatas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataEditDatas_DataProcessor30ListingDataId",
                table: "DataEditDatas",
                column: "DataProcessor30ListingDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSubProcessors_DataProcessor30ListingDataId",
                table: "DataSubProcessors",
                column: "DataProcessor30ListingDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataEditDatas");

            migrationBuilder.DropTable(
                name: "DataSubProcessors");

            migrationBuilder.DropTable(
                name: "DataProcessor30ListingDatas");
        }
    }
}
