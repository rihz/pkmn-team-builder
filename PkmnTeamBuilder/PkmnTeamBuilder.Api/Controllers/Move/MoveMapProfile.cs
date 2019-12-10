using AutoMapper;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Move
{
    public class MoveMapProfile : Profile
    {
        public MoveMapProfile()
        {
            CreateMap<PokemonMoveset, MoveModel>()
                .ForMember(d => d.Id, s => s.MapFrom(x => x.Move.Id))
                .ForMember(d => d.CategoryId, s => s.MapFrom(x => x.Move.CategoryId))
                .ForMember(d => d.CategoryName, s => s.MapFrom(x => x.Move.Category.Name))
                .ForMember(d => d.Description, s => s.MapFrom(x => x.Move.Description))
                .ForMember(d => d.Name, s => s.MapFrom(x => x.Move.Name));
        }
    }
}
