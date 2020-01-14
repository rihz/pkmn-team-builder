using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers
{
    public class NewsItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
