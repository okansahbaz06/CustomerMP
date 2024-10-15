using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerMP.DataLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTherePasso",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTherePasso",
                table: "Tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
