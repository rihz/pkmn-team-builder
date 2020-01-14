using AutoMapper;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.News
{
    public class NewsMapProfile : Profile
    {
        public NewsMapProfile()
        {
            CreateMap<NewsItem, NewsItemModel>()
                .ReverseMap();
        }
    }
}
