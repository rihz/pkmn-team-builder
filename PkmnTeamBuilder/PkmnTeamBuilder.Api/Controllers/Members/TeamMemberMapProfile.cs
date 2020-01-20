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
                .ForMember(x => x.Pokemon, y => y.MapFrom(z => z.Pokemon))
                .ForMember(x => x.Item, y => y.MapFrom(z => z.Item))
                .ForMember(x => x.Nature, y => y.MapFrom(z => z.Nature))
                .ForMember(x => x.Ability, y => y.MapFrom(z => z.Ability))
                .ForMember(x => x.Move1, y => y.MapFrom(z => z.Move1))
                .ForMember(x => x.Move2, y => y.MapFrom(z => z.Move2))
                .ForMember(x => x.Move3, y => y.MapFrom(z => z.Move3))
                .ForMember(x => x.Move4, y => y.MapFrom(z => z.Move4))
                .ForMember(x => x.HpEV, y => y.MapFrom(z => z.HPEV))
                .ForMember(x => x.HpIV, y => y.MapFrom(z => z.HPIV))
                .ForMember(x => x.SpatkEV, y => y.MapFrom(z => z.SpAtkEV))
                .ForMember(x => x.SpatkIV, y => y.MapFrom(z => z.SpAtkIV))
                .ForMember(x => x.SpdefEV, y => y.MapFrom(z => z.SpDefEV))
                .ForMember(x => x.SpdefIV, y => y.MapFrom(z => z.SpDefIV))
                .ReverseMap()
                .ForMember(x => x.Pokemon, y => y.Ignore())
                .ForMember(x => x.Item, y => y.Ignore())
                .ForMember(x => x.Nature, y => y.Ignore())
                .ForMember(x => x.Ability, y => y.Ignore())
                .ForMember(x => x.Move1, y => y.Ignore())
                .ForMember(x => x.Move2, y => y.Ignore())
                .ForMember(x => x.Move3, y => y.Ignore())
                .ForMember(x => x.Move4, y => y.Ignore())
                .ForMember(x => x.HPEV, y => y.MapFrom(z => z.HpEV))
                .ForMember(x => x.HPIV, y => y.MapFrom(z => z.HpIV))
                .ForMember(x => x.SpAtkEV, y => y.MapFrom(z => z.SpatkEV))
                .ForMember(x => x.SpAtkIV, y => y.MapFrom(z => z.SpatkIV))
                .ForMember(x => x.SpDefEV, y => y.MapFrom(z => z.SpdefEV))
                .ForMember(x => x.SpDefIV, y => y.MapFrom(z => z.SpdefIV));

            CreateMap<TeamModel, Entities.Team.Team>()
                .ForMember(x => x.Members, y => y.Ignore())
                .ReverseMap()
                .ForMember(x => x.Members, y => y.Ignore())
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.UserName))
                .ForMember(x => x.Likes, y => y.MapFrom(z => z.Likes.Count))
                .ForMember(x => x.LikedBy, y => y.MapFrom(z => z.Likes.Select(aa => aa.UserId).ToArray()));
        }
    }
}
