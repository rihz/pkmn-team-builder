﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Team
{
    public class TeamModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public string Code { get; set; }

        public DateTime LastModified { get; set; }

        public IEnumerable<TeamMemberModel> Members { get; set; }
    }
}
