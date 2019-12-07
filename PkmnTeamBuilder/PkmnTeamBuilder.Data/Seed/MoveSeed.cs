using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class MoveSeed
    {
        public static List<PokemonMove> Seed(ModelBuilder builder, List<PokemonType> types, List<PokemonMoveCategory> categories)
        {
            var resource = SeedHelper.GetResource("moves.json");

            var fullMoves = SeedHelper.ReadStream<FullMove>(resource);
            
            var moves = fullMoves
                .Select((x, index) => new PokemonMove
                {
                    Accuracy = int.Parse(x.Accuracy),
                    CategoryId = categories.First(y => y.Name.ToLower() == x.Category.ToLower()).Id,
                    Description = x.Description,
                    Id = index + 1,
                    Name = x.Name,
                    Power = x.Power != "--" ? int.Parse(x.Power) : 0,
                    PP = int.Parse(x.PP),
                    TypeId = types.First(y => y.Name.ToLower() == x.Type.ToLower()).Id
                });

            builder.Entity<PokemonMove>()
                .HasData(moves.ToArray());

            return moves.ToList();
        }
    }
}
