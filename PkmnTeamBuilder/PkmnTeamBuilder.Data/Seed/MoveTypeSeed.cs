using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class MoveTypeSeed
    {
        public static List<PokemonMoveType> Seed(ModelBuilder builder)
        {
            var moveTypes = new List<PokemonMoveType>()
            {
                CreateMoveType(1, "Level Up"),
                CreateMoveType(2, "TM"),
                CreateMoveType(3, "TR"),
                CreateMoveType(4, "Egg"),
                CreateMoveType(5, "Tutor")
            };

            builder.Entity<PokemonMoveType>()
                .HasData(moveTypes.ToArray());

            return moveTypes;
        }

        static PokemonMoveType CreateMoveType(int id, string name)
        {
            return new PokemonMoveType()
            {
                Id = id,
                Name = name
            };
        }
    }
}
