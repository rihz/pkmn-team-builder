using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class StatSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var resource = SeedHelper.GetResource("stats.json");

            var stats = SeedHelper.ReadStream<PokemonStat>(resource)
                .Select((x, index) => new PokemonStat
                {
                    Id = index + 1,
                    Name = x.Name
                });

            builder.Entity<PokemonStat>()
                .HasData(stats.ToArray());
        }
    }
}
