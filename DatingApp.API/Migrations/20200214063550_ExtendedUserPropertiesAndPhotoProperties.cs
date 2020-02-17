using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class ExtendedUserPropertiesAndPhotoProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date_created",
                table: "tbl_system_users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "birth_date",
                table: "tbl_system_users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "interests",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "introduction",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "known_as",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "when_last_active",
                table: "tbl_system_users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "looking_for",
                table: "tbl_system_users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    photo_url = table.Column<string>(nullable: true),
                    descrition = table.Column<string>(nullable: true),
                    date_added = table.Column<DateTime>(nullable: false),
                    is_profile_main_photo = table.Column<bool>(nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.photo_id);
                    table.ForeignKey(
                        name: "FK_Photos_tbl_system_users_user_id",
                        column: x => x.user_id,
                        principalTable: "tbl_system_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_user_id",
                table: "Photos",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "city",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "country",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "date_created",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "birth_date",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "interests",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "introduction",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "known_as",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "when_last_active",
                table: "tbl_system_users");

            migrationBuilder.DropColumn(
                name: "looking_for",
                table: "tbl_system_users");
        }
    }
}
