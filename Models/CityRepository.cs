using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using static Gmap.Models.City;

namespace Gmap.Models
{
    internal class CityRepository
    {
        public GeoJson ReadGeoJson()
        {
            string filePath = @"D:\Project VS\Gmap\Models\gadm41_VNM_1.json";
            string geoJsonContent = File.ReadAllText(filePath);
            GeoJson geoJson = JsonConvert.DeserializeObject<GeoJson>(geoJsonContent);
            return geoJson;
        }
    }
}
