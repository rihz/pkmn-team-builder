using Microsoft.AspNetCore.Identity;
using System;

namespace PkmnTeamBuilder.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
