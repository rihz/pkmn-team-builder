using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PkmnTeamBuilder.Api.Controllers.Move
{
    public class MoveModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int PP { get; set; }

        public int Power { get; set; }

        public int Accuracy { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
