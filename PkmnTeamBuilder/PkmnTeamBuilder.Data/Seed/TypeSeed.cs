﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PkmnTeamBuilder.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class TypeSeed
    {
        // example resource: "PkmnTeamBuilder.Data.SeedFiles.items.json"
        public static void Seed(ModelBuilder builder)
        {
            var types = new List<PokemonType>();

            var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("PkmnTeamBuilder.Data.SeedFiles.types.json");

            using (var reader = new StreamReader(resource))
            {
                var id = 1;

                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var type = JsonConvert.DeserializeObject<PokemonType>(line);
                    type.Id = id;

                    types.Add(type);

                    id++;
                }
            }

            builder.Entity<PokemonType>()
                .HasData(types.ToArray());
        }
    }
}
