using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Auth.Settings
{
    public interface IUserSettingsService
    {
        UserSettingsModel GetSettings(string userId);
        void PostSettings(string userId);
    }

    public class UserSettingsService : IUserSettingsService
    {
        ISettingsRepository _repo;

        public UserSettingsService(ISettingsRepository repo)
        {
            _repo = repo;
        }

        public UserSettingsModel GetSettings(string userId)
        {
            return _repo.GetSettings(userId);
        }

        public void PostSettings(string userId)
        {
            _repo.PostSettings(userId);
        }
    }
}
