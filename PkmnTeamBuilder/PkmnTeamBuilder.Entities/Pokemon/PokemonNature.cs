using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonNature
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Inc { get; set; }

        public string Dec { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
