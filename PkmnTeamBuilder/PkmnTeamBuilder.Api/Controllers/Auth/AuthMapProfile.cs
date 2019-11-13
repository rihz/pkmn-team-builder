using AutoMapper;
using PkmnTeamBuilder.Api.Models;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Auth
{
    public class AuthMapProfile : Profile
    {
        public AuthMapProfile()
        {
            CreateMap<SignupViewModel, AppUser>();
        }
    }
}
