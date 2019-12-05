using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PkmnTeamBuilder.Data.Migrations
{
    public partial class PokemonType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PokemonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Normal" },
                    { 16, "Dark" },
                    { 15, "Dragon" },
                    { 14, "Ghost" },
                    { 13, "Rock" },
                    { 12, "Bug" },
                    { 11, "Psychic" },
                    { 10, "Flying" },
                    { 9, "Ground" },
                    { 8, "Poison" },
                    { 7, "Fighting" },
                    { 6, "Ice" },
                    { 5, "Grass" },
                    { 4, "Electric" },
                    { 3, "Water" },
                    { 2, "Fire" },
                    { 17, "Steel" },
                    { 18, "Fairy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonTypes");
        }
    }
}
