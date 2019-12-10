using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Pokemon
{
    public class PokemonMapProfile : Profile
    {
        public PokemonMapProfile()
        {
            CreateMap<Entities.Pokemon, PokemonModel>()
                .ForMember(x => x.Type1Name, y => y.MapFrom(z => z.Type1.Name))
                .ForMember(x => x.Type2Name, y => y.MapFrom(z => z.Type2.Name))
                .ForMember(x => x.Moves, y => y.MapFrom(z => z.Moveset));
        }
    }
}
