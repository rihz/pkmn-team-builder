using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class MatchupSeed
    {
        public static void Seed(ModelBuilder builder, List<PokemonType> types)
        {
            var resource = SeedHelper.GetResource("matchups.json");

            var fullMatchups = SeedHelper.ReadStream<FullMatchup>(resource);

            var matchups = new List<PokemonMatchup>();

            var id = 1;

            foreach(var full in fullMatchups)
            {
                foreach(var modifier in full.Modifiers)
                {
                    var matchup = new PokemonMatchup()
                    {
                        DefendingTypeId = types.First(x => x.Name.ToLower() == full.DefendingType.ToLower()).Id,
                        AttackingTypeId = types.First(x => x.Name.ToLower() == modifier.Attacking.ToLower()).Id,
                        Modifier = decimal.Parse(modifier.Modifier),
                        Id = id
                    };

                    matchups.Add(matchup);
                    id++;
                }
            }

            builder.Entity<PokemonMatchup>()
                .HasData(matchups.ToArray());
        }
    }
}
