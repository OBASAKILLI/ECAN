using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECAN_CRF.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centes",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    CenterName = table.Column<string>(nullable: false),
                    CenterCode = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centes", x => x.strId);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    strStudentId = table.Column<string>(nullable: false),
                    strDate = table.Column<DateTime>(nullable: false),
                    Isdelered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.strId);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CenterId = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.strId);
                });

            migrationBuilder.CreateTable(
                name: "sponsers",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    stName = table.Column<string>(nullable: false),
                    stImageURl = table.Column<string>(nullable: true),
                    stCountry = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sponsers", x => x.strId);
                });

            migrationBuilder.CreateTable(
                name: "studens",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    strName = table.Column<string>(nullable: false),
                    strADNo = table.Column<string>(nullable: false),
                    strCenterId = table.Column<string>(nullable: false),
                    strSchoolId = table.Column<string>(nullable: false),
                    strSponserId = table.Column<string>(nullable: false),
                    strGuarduianName = table.Column<string>(nullable: false),
                    strguardianPhone = table.Column<string>(nullable: false),
                    strCgrade_Class = table.Column<string>(nullable: false),
                    strADMDate = table.Column<DateTime>(nullable: false),
                    strDateOfBirth = table.Column<DateTime>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studens", x => x.strId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    strId = table.Column<string>(maxLength: 50, nullable: false),
                    strName = table.Column<string>(nullable: false),
                    strUsername = table.Column<string>(nullable: false),
                    strRole = table.Column<string>(nullable: false),
                    strPassword = table.Column<string>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.strId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "centes");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "schools");

            migrationBuilder.DropTable(
                name: "sponsers");

            migrationBuilder.DropTable(
                name: "studens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
