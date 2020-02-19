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

            migrationBuilder.CreateTable(
                name: "tbl_system_users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(nullable: true),
                    password_hash = table.Column<byte[]>(nullable: true),
                    password_salt = table.Column<byte[]>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    birth_date = table.Column<DateTime>(nullable: false),
                    known_as = table.Column<string>(nullable: true),
                    date_created = table.Column<DateTime>(nullable: false),
                    when_last_active = table.Column<DateTime>(nullable: false),
                    introduction = table.Column<string>(nullable: true),
                    looking_for = table.Column<string>(nullable: true),
                    interests = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_system_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    photo_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    photo_url = table.Column<string>(nullable: true),
                    descrition = table.Column<string>(nullable: true),
                    date_added = table.Column<DateTime>(nullable: false),
                    public_cloudinary_id = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "tbl_users_likes",
                columns: table => new
                {
                    like_id = table.Column<int>(nullable: false),
                    likee_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users_likes", x => new { x.like_id, x.likee_id });
                    table.ForeignKey(
                        name: "FK_tbl_users_likes_tbl_system_users_likee_id",
                        column: x => x.likee_id,
                        principalTable: "tbl_system_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_users_likes_tbl_system_users_like_id",
                        column: x => x.like_id,
                        principalTable: "tbl_system_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_user_id",
                table: "Photos",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_likes_likee_id",
                table: "tbl_users_likes",
                column: "likee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "tbl_animals");

            migrationBuilder.DropTable(
                name: "tbl_users_likes");

            migrationBuilder.DropTable(
                name: "tbl_system_users");
        }
    }
}
