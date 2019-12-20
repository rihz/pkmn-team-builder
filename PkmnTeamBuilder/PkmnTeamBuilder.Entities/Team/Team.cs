using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities.Team
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Likes { get; set; }

        public string Code { get; set; }

        public DateTime LastModified { get; set; }
    }
}
