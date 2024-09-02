using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmap.Models
{
    internal class Road
    {
        public class Crs
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Feature
        {
            public string type { get; set; }
            public Properties properties { get; set; }
            public Geometry geometry { get; set; }
        }

        public class Geometry
        {
            public string type { get; set; }
            public List<List<List<double>>> coordinates { get; set; }
        }

        public class Properties
        {
            public string name { get; set; }
            public int gid { get; set; }
            public string ma { get; set; }
            public string ten { get; set; }
            public string loai_duong { get; set; }
            public string cap_duong { get; set; }
            public double chieu_dai { get; set; }
            public string map_id { get; set; }
        }

        internal class GeoJson
        {
            public string type { get; set; }
            public Crs crs { get; set; }
            public List<Feature> features { get; set; }
        }
    }

}
