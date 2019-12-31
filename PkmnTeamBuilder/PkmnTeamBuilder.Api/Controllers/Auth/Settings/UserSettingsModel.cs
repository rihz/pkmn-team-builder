using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers
{
    public class UserSettingsModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Theme { get; set; }

        public bool SortTeamsAscending { get; set; }
    }
}
