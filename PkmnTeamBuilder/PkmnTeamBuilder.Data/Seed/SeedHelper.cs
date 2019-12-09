using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace PkmnTeamBuilder.Data.Seed
{
    public static class SeedHelper
    {
        const string NAMESPACE = "PkmnTeamBuilder.Data.SeedFiles.";

        public static Stream GetResource(string name)
        {
            return Assembly.GetManifestResourceStream(NAMESPACE + name);
        }
        public static IEnumerable<T> ReadStream<T>(Stream stream)
        {
            var objects = new List<T>();
            
            using (var reader = new StreamReader(stream))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                    var obj = JsonConvert.DeserializeObject<T>(line);

                    objects.Add(obj);
                }
            }

            return objects;
        }

        static Assembly Assembly
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly();
            }
        }
    }
}
