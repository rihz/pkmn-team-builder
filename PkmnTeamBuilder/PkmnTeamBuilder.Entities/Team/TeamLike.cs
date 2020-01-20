using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities.Team
{
    public class TeamLike
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string UserId { get; set; }

        public virtual Team Team { get; set; }
        public virtual AppUser User { get; set; }
    }
}
