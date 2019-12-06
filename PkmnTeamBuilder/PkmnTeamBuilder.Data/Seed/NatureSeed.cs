using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class NatureSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var resource = SeedHelper.GetResource("natures.json");

            var natures = SeedHelper.ReadStream<PokemonNature>(resource)
                .Select((x, index) => new PokemonNature
                {
                    Id = index + 1,
                    Name = x.Name,
                    Inc = x.Inc,
                    Dec = x.Dec
                });

            builder.Entity<PokemonNature>()
                .HasData(natures.ToArray());
        }
    }
}
