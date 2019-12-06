using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class AbilitySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var resource = SeedHelper.GetResource("abilities.json");

            var abilities = SeedHelper.ReadStream<PokemonAbility>(resource)
                .Select((x, index) => new PokemonAbility
                {
                    Id = index + 1,
                    Name = x.Name,
                    Description = x.Description
                });

            builder.Entity<PokemonAbility>()
                .HasData(abilities.ToArray());
        }
    }
}
