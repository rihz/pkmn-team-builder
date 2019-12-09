using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonMoveType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PokemonMoveset> Moveset { get; set; }
    }
}
