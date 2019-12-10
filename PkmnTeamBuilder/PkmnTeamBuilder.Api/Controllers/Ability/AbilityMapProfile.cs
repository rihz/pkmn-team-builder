using AutoMapper;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Ability
{
    public class AbilityMapProfile : Profile
    {
        public AbilityMapProfile()
        {
            CreateMap<PokemonAbilityset, AbilityModel>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Ability.Id))
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Ability.Name))
                .ForMember(d => d.Description, s => s.MapFrom(x => x.Ability.Description));
        }
    }
}
