using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
