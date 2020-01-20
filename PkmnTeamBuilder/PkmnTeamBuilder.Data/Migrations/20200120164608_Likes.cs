using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PkmnTeamBuilder.Data.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Team");

            migrationBuilder.CreateTable(
                name: "TeamLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TeamId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLikes_Team",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_TeamMember",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamLikes_TeamId",
                table: "TeamLikes",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLikes_UserId",
                table: "TeamLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamLikes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Team",
                nullable: false,
                defaultValue: 0);
        }
    }
}
