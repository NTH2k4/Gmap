using Newtonsoft.Json;
using System.Reflection;
using static Gmap.Models.Road;

namespace Gmap.Models
{
    internal class RoadRepository
    {
        public GeoJson ReadRoad()
        {
            /*string filePath = @"D:\Project VS\Gmap\Models\giaothong.geojson";
            string geoJsonContent = File.ReadAllText(filePath);
            GeoJson geoJson = JsonConvert.DeserializeObject<GeoJson>(geoJsonContent);
            return geoJson;*/
            string resourceName = "Gmap.Models.giaothong.geojson";
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string geoJsonContent = reader.ReadToEnd();
                GeoJson geoJson = JsonConvert.DeserializeObject<GeoJson>(geoJsonContent);
                return geoJson;
            }
        }
    }
}
