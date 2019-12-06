using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonMatchup
    {
        [Key]
        public int Id { get; set; }

        public int DefendingTypeId { get; set; }

        public int AttackingTypeId { get; set; }

        public decimal Modifier { get; set; }

        public virtual PokemonType DefendingType { get; set; }

        public virtual PokemonType AttackingType { get; set; }
    }

    public class FullMatchup
    {
        public string DefendingType { get; set; }

        public List<Matchup> Modifiers { get; set; }
    }

    public class Matchup
    {
        public string Attacking { get; set; }

        public string Modifier { get; set; }
    }
}
