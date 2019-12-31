using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PkmnTeamBuilder.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Team.Team> Teams { get; set; }

        public virtual ICollection<TeamMember> TeamMembers { get; set; }

        public virtual UserSetting Settings { get; set; }
    }
}
