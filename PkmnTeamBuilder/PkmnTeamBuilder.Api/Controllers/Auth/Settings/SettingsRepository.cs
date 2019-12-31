using AutoMapper;
using PkmnTeamBuilder.Data.Context;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers
{
    public interface ISettingsRepository
    {
        UserSettingsModel GetSettings(string userId);
        void PostSettings(string userId);
    }

    public class SettingsRepository : ISettingsRepository
    {
        TeamBuilderContext _context;
        IMapper _mapper;

        public SettingsRepository(TeamBuilderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserSettingsModel GetSettings(string userId)
        {
            var settings = _context.UserSetting.FirstOrDefault(x => x.UserId == userId);

            return _mapper.Map<UserSettingsModel>(settings);
        }

        public void PostSettings(string userId)
        {
            var settings = new UserSetting
            {
                UserId = userId,
                Theme = "charmander",
                SortTeamsAscending = false
            };

            _context.UserSetting.Add(settings);

            _context.SaveChanges();
        }
    }
}
