using PkmnTeamBuilder.Api.Controllers.Ability;
using PkmnTeamBuilder.Api.Controllers.Move;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Pokemon
{
    public class PokemonModel
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

        public int Type1Id { get; set; }

        public string Type1Name { get; set; }

        public int? Type2Id { get; set; }

        public string Type2Name { get; set; }

        public IEnumerable<MoveModel> Moves { get; set; }

        public IEnumerable<AbilityModel> Abilities { get; set; }
    }

    public class PokemonSearchResultModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public string Icon { get; set; }
    }
}
