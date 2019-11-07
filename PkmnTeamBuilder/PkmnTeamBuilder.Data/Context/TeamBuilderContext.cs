using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PkmnTeamBuilder.Data.Context
{
    public class TeamBuilderContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> Users { get; set; }

        public TeamBuilderContext(DbContextOptions options)
            : base(options)
        { }
    }
}
