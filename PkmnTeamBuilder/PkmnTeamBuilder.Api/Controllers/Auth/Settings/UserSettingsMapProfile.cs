using AutoMapper;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Auth.Settings
{
    public class UserSettingsMapProfile : Profile
    {
        public UserSettingsMapProfile()
        {
            CreateMap<UserSetting, UserSettingsModel>()
                .ReverseMap()
                .ForMember(x => x.User, y => y.Ignore());
        }
    }
}
