using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class CategorySeed
    {
        public static List<PokemonMoveCategory> Seed(ModelBuilder builder)
        {
            var categories = new List<PokemonMoveCategory>()
            {
                new PokemonMoveCategory() { Id = 1, Name = "Physical" },
                new PokemonMoveCategory() { Id = 2, Name = "Special" },
                new PokemonMoveCategory() { Id = 3, Name = "Other" }
            };

            builder.Entity<PokemonMoveCategory>()
                .HasData(categories.ToArray());

            return categories;
        }
    }
}
