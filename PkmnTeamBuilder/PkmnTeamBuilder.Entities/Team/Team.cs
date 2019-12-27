using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities.Team
{
    public class Team
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public string Code { get; set; }

        public DateTime LastModified { get; set; }

        public virtual ICollection<TeamMembers> Members { get; set; }

        public virtual AppUser User { get; set; }
    }

    public class TeamMembers
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int TeamMemberId { get; set; }

        public virtual Team Team { get; set; }

        public virtual TeamMember TeamMember { get; set; }
    }
}
