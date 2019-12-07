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
        public static void Seed(ModelBuilder builder, List<PokemonType> types)
        {
            var resource = SeedHelper.GetResource("pokemon.json");

            var fullPokemon = SeedHelper.ReadStream<FullPokemon>(resource);

            var pokemon = fullPokemon
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
                    Type2Id = x.Type2 != "" ? types.First(y => y.Name.ToLower() == x.Type2.ToLower()).Id : null as int?
                });

            builder.Entity<Pokemon>()
                .HasData(pokemon.ToArray());


        }
    }
}
