using Microsoft.EntityFrameworkCore.Migrations;

namespace PkmnTeamBuilder.Data.Migrations
{
    public partial class FixNatureSPE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 3,
                column: "Dec",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 8,
                column: "Dec",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 11,
                column: "Inc",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 12,
                column: "Inc",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 14,
                column: "Inc",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 15,
                column: "Inc",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 18,
                column: "Dec",
                value: "SPE");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 23,
                column: "Dec",
                value: "SPE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 3,
                column: "Dec",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 8,
                column: "Dec",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 11,
                column: "Inc",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 12,
                column: "Inc",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 14,
                column: "Inc",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 15,
                column: "Inc",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 18,
                column: "Dec",
                value: "SPD");

            migrationBuilder.UpdateData(
                table: "PokemonNature",
                keyColumn: "Id",
                keyValue: 23,
                column: "Dec",
                value: "SPD");
        }
    }
}
