using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonStat
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
