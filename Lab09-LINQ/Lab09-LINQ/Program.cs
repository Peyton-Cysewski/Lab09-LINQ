using System;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Lab09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalyzeNeighborhoods();
        }

        static void AnalyzeNeighborhoods()
        {
            // Getting the JSON data
            JObject data = JObject.Parse(File.ReadAllText(@"../../../../data.json"));
            JArray features = (JArray)data["features"];
            IList<Feature> featList = features.ToObject<IList<Feature>>();

            // Queries

            IEnumerable<string> neighborhoods = from area in featList select area.properties.neighborhood;
            Console.WriteLine($"There are {neighborhoods.Count()} total neighborhoods represented in the data set.");
            Console.ReadLine();
            Console.Clear();

            IEnumerable<string> notEmpty = from name in neighborhoods where name != "" select name;
            Console.WriteLine($"There are {notEmpty.Count()} neighborhoods that actually have names.");
            Console.ReadLine();
            Console.Clear();

            IEnumerable<string> notDupl = notEmpty.Distinct();
            Console.WriteLine($"There are {notDupl.Count()} neighborhoods that are unique.");
            Console.ReadLine();
            Console.Clear();

            IEnumerable<string> allInOne = featList
                                            .Select(x => x.properties.neighborhood)
                                            .Where(x => x != "")
                                            .Distinct();
            Console.WriteLine($"{allInOne.Count()} neighborhoods are selected when all queries are chained together.");
            Console.ReadLine();
            Console.Clear();

            IEnumerable<string> redoOne = 

        }

    }

    // using https://json2csharp.com/
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }

    }

    public class Properties
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string address { get; set; }
        public string borough { get; set; }
        public string neighborhood { get; set; }
        public string county { get; set; }

    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }

    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }

    }


}
