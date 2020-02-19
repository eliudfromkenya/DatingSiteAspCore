using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Migrations
{
    public partial class AddedMessagingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    message_id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sender_id = table.Column<int>(nullable: false),
                    receipient_id = table.Column<int>(nullable: false),
                    message_content = table.Column<string>(nullable: true),
                    message_is_read = table.Column<bool>(nullable: false),
                    message_date_was_read = table.Column<DateTime>(nullable: true),
                    message_sent = table.Column<DateTime>(nullable: false),
                    sender_deleted = table.Column<bool>(nullable: false),
                    recipient_deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.message_id);
                    table.ForeignKey(
                        name: "FK_Messages_tbl_system_users_receipient_id",
                        column: x => x.receipient_id,
                        principalTable: "tbl_system_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_tbl_system_users_sender_id",
                        column: x => x.sender_id,
                        principalTable: "tbl_system_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_receipient_id",
                table: "Messages",
                column: "receipient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_sender_id",
                table: "Messages",
                column: "sender_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
