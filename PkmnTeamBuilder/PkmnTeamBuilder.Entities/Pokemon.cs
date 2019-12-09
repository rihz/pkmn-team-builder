using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Icon { get; set; }

        public int BaseHP { get; set; }

        public int BaseAtk { get; set; }

        public int BaseDef { get; set; }

        public int BaseSpAtk { get; set; }

        public int BaseSpDef { get; set; }

        public int BaseSpe { get; set; }

        public string Image { get; set; }

        public string Shiny { get; set; }

        public int Type1Id { get; set; }

        public int? Type2Id { get; set; }

        public virtual PokemonType Type1 { get; set; }

        public virtual PokemonType Type2 { get; set; }

        public virtual ICollection<PokemonMoveset> Moveset { get; set; }

        public virtual ICollection<PokemonAbilityset> Abilities { get; set; }
    }

    public class FullPokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Icon { get; set; }

        public int BaseHP { get; set; }

        public int BaseAtk { get; set; }

        public int BaseDef { get; set; }

        public int BaseSpAtk { get; set; }

        public int BaseSpDef { get; set; }

        public int BaseSpe { get; set; }

        public string Image { get; set; }

        public string Shiny { get; set; }

        public string Type1 { get; set; }

        public string Type2 { get; set; }

        public Moves Moves { get; set; }
    }

    public class Moves
    {
        public string[] LevelUp { get; set; }

        public string[] TM { get; set; }

        public string[] TR { get; set; }

        public string[] Egg { get; set; }

        public string[] Tutor { get; set; }
    }

    public class PokemonMoveset
    {
        public int Id { get; set; }

        public int PokemonId { get; set; }

        public int MoveId { get; set; }

        public int MoveTypeId { get; set; }

        public virtual Pokemon Pokemon { get; set; }

        public virtual PokemonMove Move { get; set; }

        public virtual PokemonMoveType MoveType { get; set; }
    }

    public class PokemonAbilityset
    {
        public int Id { get; set; }

        public int PokemonId { get; set; }

        public int AbilityId { get; set; }

        public virtual Pokemon Pokemon { get; set; }

        public virtual PokemonAbility Ability { get; set; }
    }
}
