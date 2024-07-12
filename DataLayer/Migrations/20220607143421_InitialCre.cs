using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerMP.DataLayer.Migrations
{
    public partial class InitialCre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tc = table.Column<string>(maxLength: 11, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HomePhoneNo = table.Column<string>(nullable: true),
                    WorkPhoneNo = table.Column<string>(nullable: true),
                    MobilePhoneNo = table.Column<string>(nullable: true),
                    HomeAdress = table.Column<string>(nullable: true),
                    WorkAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
