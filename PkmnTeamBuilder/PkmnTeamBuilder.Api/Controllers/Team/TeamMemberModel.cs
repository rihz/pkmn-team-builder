using PkmnTeamBuilder.Api.Controllers.Ability;
using PkmnTeamBuilder.Api.Controllers.Item;
using PkmnTeamBuilder.Api.Controllers.Move;
using PkmnTeamBuilder.Api.Controllers.Nature;
using PkmnTeamBuilder.Api.Controllers.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public class TeamMemberModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

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

        public string Notes { get; set; }

        public PokemonModel Pokemon { get; set; }

        public AbilityModel Ability { get; set; }

        public ItemModel Item { get; set; }

        public NatureModel Nature { get; set; }

        public MoveModel Move1 { get; set; }

        public MoveModel Move2 { get; set; }

        public MoveModel Move3 { get; set; }

        public MoveModel Move4 { get; set; }
    }
}
