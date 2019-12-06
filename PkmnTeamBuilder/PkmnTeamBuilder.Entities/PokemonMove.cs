using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonMove
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }

        public int CategoryId { get; set; }

        public int PP { get; set; }

        public int Power { get; set; }

        public int Accuracy { get; set; }

        public string Description { get; set; }

        public virtual PokemonType Type { get; set; }

        public virtual PokemonMoveCategory Category { get; set; }
    }

    public class FullMove
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Category { get; set; }

        public string PP { get; set; }

        public string Power { get; set; }

        public string Accuracy { get; set; }

        public string Description { get; set; }
    }
}
