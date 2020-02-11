using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_animals",
                columns: table => new
                {
                    animal_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    animal_name = table.Column<string>(nullable: true),
                    date_of_birth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_animals", x => x.animal_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_animals");
        }
    }
}
