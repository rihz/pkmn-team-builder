using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class TypeSeed
    {
        // example resource: "PkmnTeamBuilder.Data.SeedFiles.items.json"
        public static void Seed(ModelBuilder builder)
        {
            Assembly.GetExecutingAssembly().GetManifestResourceNames();

            var l = 'l';
        }
    }
}
