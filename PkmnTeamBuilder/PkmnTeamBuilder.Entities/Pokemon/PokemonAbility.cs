﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class PokemonAbility
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<PokemonAbilityset> Abilityset { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }

    public class PokemonAbilities
    {
        public string PokemonName { get; set; }

        public string[] AbilityNames { get; set; }
    }
}
