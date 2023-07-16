using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_messages_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageSenderId = table.Column<int>(type: "int", nullable: false),
                    MessageReceiverId = table.Column<int>(type: "int", nullable: false),
                    MessageSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Authors_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                    table.ForeignKey(
                        name: "FK_Messages_Authors_MessageSenderId",
                        column: x => x.MessageSenderId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageReceiverId",
                table: "Messages",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageSenderId",
                table: "Messages",
                column: "MessageSenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
