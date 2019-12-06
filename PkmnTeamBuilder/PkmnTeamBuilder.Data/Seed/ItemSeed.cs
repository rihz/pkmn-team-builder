using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class ItemSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var resource = SeedHelper.GetResource("items.json");

            var items = SeedHelper.ReadStream<PokemonItem>(resource)
                .Select((x, index) => new PokemonItem
                {
                    Id = index + 1,
                    Name = x.Name,
                    Icon = x.Icon,
                    Description = x.Description
                });

            builder.Entity<PokemonItem>()
                .HasData(items.ToArray());
        }
    }
}
