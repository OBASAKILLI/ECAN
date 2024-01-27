using Microsoft.EntityFrameworkCore.Migrations;

namespace ECAN_CRF.Migrations
{
    public partial class bafsgfdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "strEvent",
                table: "events",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "strEvent",
                table: "events");
        }
    }
}
