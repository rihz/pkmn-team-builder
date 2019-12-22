using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
