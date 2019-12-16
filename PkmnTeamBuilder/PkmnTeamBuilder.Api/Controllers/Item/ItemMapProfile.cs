using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Item
{
    public class ItemMapProfile : Profile
    {
        public ItemMapProfile()
        {
            CreateMap<Entities.PokemonItem, ItemModel>();
        }
    }
}
