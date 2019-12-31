using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class UserSetting
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Theme { get; set; }

        public bool SortTeamsAscending { get; set; }

        public virtual AppUser User { get; set; }
    }
}
