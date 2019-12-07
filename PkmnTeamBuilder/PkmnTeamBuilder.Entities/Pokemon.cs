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

        public virtual ICollection<PokemonAbility> Abilities { get; set; }

        public virtual ICollection<PokemonMove> LevelUpMoves { get; set; }

        public virtual ICollection<PokemonMove> TMs { get; set; }

        public virtual ICollection<PokemonMove> TRs { get; set; }

        public virtual ICollection<PokemonMove> EggMoves { get; set; }

        public virtual ICollection<PokemonMove> TutorMoves { get; set; }
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
}
