using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PokemonMatchup> Attacking { get; set; }

        public virtual ICollection<PokemonMatchup> Defending { get; set; }

        public virtual ICollection<PokemonMove> Moves { get; set; }
    }
}
