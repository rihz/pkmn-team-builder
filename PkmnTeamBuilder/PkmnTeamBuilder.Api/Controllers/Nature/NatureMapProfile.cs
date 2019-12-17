using AutoMapper;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Nature
{
    public class NatureMapProfile : Profile
    {
        public NatureMapProfile()
        {
            CreateMap<PokemonNature, NatureModel>()
                .ForMember(x => x.Increase, y => y.MapFrom(z => z.Inc))
                .ForMember(x => x.Decrease, y => y.MapFrom(z => z.Dec));
        }
    }
}
