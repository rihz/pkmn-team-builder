using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PkmnTeamBuilder.Data.Migrations
{
    public partial class TeamMemberNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PokemonId = table.Column<int>(nullable: false),
                    AbilityId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    NatureId = table.Column<int>(nullable: false),
                    Move1Id = table.Column<int>(nullable: false),
                    Move2Id = table.Column<int>(nullable: false),
                    Move3Id = table.Column<int>(nullable: false),
                    Move4Id = table.Column<int>(nullable: false),
                    Nickname = table.Column<string>(nullable: true),
                    HPEV = table.Column<int>(nullable: false),
                    AtkEV = table.Column<int>(nullable: false),
                    DefEV = table.Column<int>(nullable: false),
                    SpAtkEV = table.Column<int>(nullable: false),
                    SpDefEV = table.Column<int>(nullable: false),
                    SpeEV = table.Column<int>(nullable: false),
                    HPIV = table.Column<int>(nullable: false),
                    AtkIV = table.Column<int>(nullable: false),
                    DefIV = table.Column<int>(nullable: false),
                    SpAtkIV = table.Column<int>(nullable: false),
                    SpDefIV = table.Column<int>(nullable: false),
                    SpeIV = table.Column<int>(nullable: false),
                    IsShiny = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMember_PokemonAbility",
                        column: x => x.AbilityId,
                        principalTable: "PokemonAbility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Item",
                        column: x => x.ItemId,
                        principalTable: "PokemonItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Move1",
                        column: x => x.Move1Id,
                        principalTable: "PokemonMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Move2",
                        column: x => x.Move2Id,
                        principalTable: "PokemonMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Move3",
                        column: x => x.Move3Id,
                        principalTable: "PokemonMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Move4",
                        column: x => x.Move4Id,
                        principalTable: "PokemonMove",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Nature",
                        column: x => x.NatureId,
                        principalTable: "PokemonNature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_Pokemon",
                        column: x => x.PokemonId,
                        principalTable: "Pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_AbilityId",
                table: "TeamMember",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_ItemId",
                table: "TeamMember",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_Move1Id",
                table: "TeamMember",
                column: "Move1Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_Move2Id",
                table: "TeamMember",
                column: "Move2Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_Move3Id",
                table: "TeamMember",
                column: "Move3Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_Move4Id",
                table: "TeamMember",
                column: "Move4Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_NatureId",
                table: "TeamMember",
                column: "NatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_PokemonId",
                table: "TeamMember",
                column: "PokemonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMember");
        }
    }
}
