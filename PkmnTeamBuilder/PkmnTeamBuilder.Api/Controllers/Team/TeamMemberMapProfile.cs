using AutoMapper;
using PkmnTeamBuilder.Api.Controllers.Team;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers
{
    public class TeamMemberMapProfile : Profile
    {
        public TeamMemberMapProfile()
        {
            CreateMap<TeamMember, TeamMemberModel>()
                .ReverseMap()
                .ForMember(x => x.Pokemon, y => y.Ignore())
                .ForMember(x => x.Item, y => y.Ignore())
                .ForMember(x => x.Nature, y => y.Ignore())
                .ForMember(x => x.Ability, y => y.Ignore())
                .ForMember(x => x.Move1, y => y.Ignore())
                .ForMember(x => x.Move2, y => y.Ignore())
                .ForMember(x => x.Move3, y => y.Ignore())
                .ForMember(x => x.Move4, y => y.Ignore());

            CreateMap<TeamModel, Entities.Team.Team>()
                .ForMember(x => x.Members, y => y.Ignore())
                .ReverseMap()
                .ForMember(x => x.Members, y => y.MapFrom(z => z.Members));
        }
    }
}
