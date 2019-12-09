using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class PokemonSeed
    {
        public static void Seed(ModelBuilder builder, List<PokemonType> types, List<PokemonMoveType> moveTypes, List<PokemonMove> moves, List<PokemonAbility> abilities)
        {
            var resource = SeedHelper.GetResource("pokemon.json");
            var abilityResource = SeedHelper.GetResource("pokemonAbilities.json");

            var fullPokemon = SeedHelper.ReadStream<FullPokemon>(resource);

            var fullAbilities = SeedHelper.ReadStream<PokemonAbilities>(abilityResource);
            IEnumerable<Pokemon> pokemon = null;

            pokemon = fullPokemon
            .Select((x, index) => new Pokemon
            {
                BaseAtk = x.BaseAtk,
                BaseDef = x.BaseDef,
                BaseHP = x.BaseHP,
                BaseSpAtk = x.BaseSpAtk,
                BaseSpDef = x.BaseSpDef,
                BaseSpe = x.BaseSpe,
                Icon = x.Icon,
                Id = index + 1,
                Image = x.Image,
                Name = x.Name,
                Number = x.Number,
                Shiny = x.Shiny,
                Type1Id = types.First(y => y.Name.ToLower() == x.Type1.ToLower()).Id,
                Type2Id = x.Type2 != null ? types.First(y => y.Name.ToLower() == x.Type2.ToLower()).Id : null as int?
            });

            builder.Entity<Pokemon>()
                .HasData(pokemon.ToArray());

            var abilityset = new List<PokemonAbilityset>();
            var moveset = new List<PokemonMoveset>();

            var moveCounter = 1;
            var abilityCounter = 1;

            foreach (var pkmn in fullPokemon)
            {
                var id = pokemon.First(x => x.Name == pkmn.Name).Id;

                moveset.AddRange(CreateMoveset(pkmn.Moves.LevelUp, moves, moveTypes, "Level Up", id, ref moveCounter));
                moveset.AddRange(CreateMoveset(pkmn.Moves.TM, moves, moveTypes, "TM", id, ref moveCounter));
                moveset.AddRange(CreateMoveset(pkmn.Moves.TR, moves, moveTypes, "TR", id, ref moveCounter));
                moveset.AddRange(CreateMoveset(pkmn.Moves.Egg, moves, moveTypes, "Egg", id, ref moveCounter));
                moveset.AddRange(CreateMoveset(pkmn.Moves.Tutor, moves, moveTypes, "Tutor", id, ref moveCounter));

                var abils = fullAbilities.First(x => x.PokemonName.ToLower() == pkmn.Name.ToLower());

                foreach (var abil in abils.AbilityNames)
                {
                    abilityset.Add(new PokemonAbilityset()
                    {
                        Id = abilityCounter++,
                        AbilityId = abilities.First(x => x.Name.ToLower() == abil.ToLower()).Id,
                        PokemonId = id
                    });
                }
            }

            builder.Entity<PokemonMoveset>()
                .HasData(moveset.ToArray());

            builder.Entity<PokemonAbilityset>()
                .HasData(abilityset.ToArray());
        }

        static IEnumerable<PokemonMoveset> CreateMoveset(string[] moveNames, List<PokemonMove> moves, List<PokemonMoveType> moveTypes, string name, int pokemonId, ref int id)
        {
            var moveset = new List<PokemonMoveset>();

            foreach(var move in moveNames)
            {
                moveset.Add(new PokemonMoveset
                {
                    Id = id++,
                    MoveId = moves.Any(y => y.Name.ToLower() == move.ToLower()) ? moves.First(y => y.Name.ToLower() == move.ToLower()).Id : 0,
                    MoveTypeId = moveTypes.Any(y => y.Name == name) ? moveTypes.First(y => y.Name == name).Id : 0,
                    PokemonId = pokemonId
                });
            }

            return moveset;
        }
    }
}
