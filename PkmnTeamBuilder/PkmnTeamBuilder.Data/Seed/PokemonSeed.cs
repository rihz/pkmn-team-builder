using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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

            try
            {
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
            }
            catch(Exception ex)
            {
                Debugger.Launch();
                var l = 'l';
            }

            builder.Entity<Pokemon>()
                .HasData(pokemon.ToArray());

            var levelUps = new List<PokemonMoveset>();
            var tms = new List<PokemonMoveset>();
            var trs = new List<PokemonMoveset>();
            var eggs = new List<PokemonMoveset>();
            var tutors = new List<PokemonMoveset>();

            var abilityset = new List<PokemonAbilityset>();

            var moveCounter = 1;
            var abilityCounter = 1;

            foreach(var pkmn in fullPokemon)
            {
                levelUps.AddRange(CreateMoveset(pkmn.Moves.LevelUp, moves, moveTypes, "Level Up", pkmn.Id, moveCounter++));
                tms.AddRange(CreateMoveset(pkmn.Moves.TM, moves, moveTypes, "TM", pkmn.Id, moveCounter++));
                trs.AddRange(CreateMoveset(pkmn.Moves.TR, moves, moveTypes, "TR", pkmn.Id, moveCounter++));
                eggs.AddRange(CreateMoveset(pkmn.Moves.Egg, moves, moveTypes, "Egg", pkmn.Id, moveCounter++));
                tutors.AddRange(CreateMoveset(pkmn.Moves.Tutor, moves, moveTypes, "Tutor", pkmn.Id, moveCounter++));

                var abils = fullAbilities.First(x => x.PokemonName.ToLower() == pkmn.Name.ToLower());

                foreach(var abil in abils.AbilityNames)
                {
                    abilityset.Add(new PokemonAbilityset()
                    {
                        Id = abilityCounter++,
                        AbilityId = abilities.First(x => x.Name.ToLower() == abil.ToLower()).Id,
                        PokemonId = pkmn.Id
                    });
                }
            }

            builder.Entity<PokemonMoveset>()
                .HasData(
                levelUps.ToArray(),
                tms.ToArray(),
                trs.ToArray(),
                eggs.ToArray(),
                tutors.ToArray()
            );

            builder.Entity<PokemonAbilityset>()
                .HasData(abilityset.ToArray());
        }

        static IEnumerable<PokemonMoveset> CreateMoveset(string[] moveNames, List<PokemonMove> moves, List<PokemonMoveType> moveTypes, string name, int pokemonId, int id)
        {
            return moveNames.Select((x, index) => new PokemonMoveset
            {
                Id = id,
                MoveId = moves.First(y => y.Name.ToLower() == x.ToLower()).Id,
                MoveTypeId = moveTypes.First(y => y.Name == name).Id,
                PokemonId = pokemonId
            });
        }
    }
}
