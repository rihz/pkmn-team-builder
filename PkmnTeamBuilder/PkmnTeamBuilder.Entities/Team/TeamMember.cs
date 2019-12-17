using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }

        public int PokemonId { get; set; }

        public int AbilityId { get; set; }

        public int ItemId { get; set; }

        public int NatureId { get; set; }

        public int Move1Id { get; set; }

        public int Move2Id { get; set; }

        public int Move3Id { get; set; }

        public int Move4Id { get; set; }

        public string Nickname { get; set; }

        public int HPEV { get; set; }

        public int AtkEV { get; set; }

        public int DefEV { get; set; }

        public int SpAtkEV { get; set; }

        public int SpDefEV { get; set; }

        public int SpeEV { get; set; }

        public int HPIV { get; set; }

        public int AtkIV { get; set; }

        public int DefIV { get; set; }

        public int SpAtkIV { get; set; }

        public int SpDefIV { get; set; }

        public int SpeIV { get; set; }

        public bool IsShiny { get; set; }

        public virtual Pokemon Pokemon { get; set; }

        public virtual PokemonAbility Ability { get; set; }

        public virtual PokemonItem Item { get; set; }

        public virtual PokemonNature Nature { get; set; }

        public virtual PokemonMove Move1 { get; set; }

        public virtual PokemonMove Move2 { get; set; }

        public virtual PokemonMove Move3 { get; set; }

        public virtual PokemonMove Move4 { get; set; }
    }
}
