using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonMoveCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<PokemonMove> Moves { get; set; }
    }
}
