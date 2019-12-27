using Microsoft.EntityFrameworkCore.Migrations;

namespace PkmnTeamBuilder.Data.Migrations
{
    public partial class UserFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TeamMember",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Team",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_User",
                table: "Team",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_User",
                table: "TeamMember",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_User",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_User",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_TeamMember_UserId",
                table: "TeamMember");

            migrationBuilder.DropIndex(
                name: "IX_Team_UserId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeamMember");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "Username");
        }
    }
}
