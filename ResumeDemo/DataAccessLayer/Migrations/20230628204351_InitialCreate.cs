using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Languages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AdminId",
                table: "Skills",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_AdminId",
                table: "Languages",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_AdminId",
                table: "Experiences",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AdminId",
                table: "Educations",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_AdminId",
                table: "Abouts",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Admins_AdminId",
                table: "Abouts",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Admins_AdminId",
                table: "Educations",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Admins_AdminId",
                table: "Experiences",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Admins_AdminId",
                table: "Languages",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Admins_AdminId",
                table: "Skills",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Admins_AdminId",
                table: "Abouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Admins_AdminId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Admins_AdminId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Admins_AdminId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Admins_AdminId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_AdminId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Languages_AdminId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_AdminId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_AdminId",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_AdminId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Abouts");
        }
    }
}
