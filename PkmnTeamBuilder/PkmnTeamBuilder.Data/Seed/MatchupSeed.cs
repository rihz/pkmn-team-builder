using Microsoft.EntityFrameworkCore;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public class MatchupSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var resource = SeedHelper.GetResource("matchups.json");

            var matchups = SeedHelper.ReadStream<FullMatchup>(resource);
            Debugger.Launch();
            var l = 'l';
        }
    }
}
