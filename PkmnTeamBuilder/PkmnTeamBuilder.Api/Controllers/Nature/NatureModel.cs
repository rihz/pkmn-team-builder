using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Nature
{
    public class NatureModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Increase { get; set; }

        public string Decrease { get; set; }
    }
}
