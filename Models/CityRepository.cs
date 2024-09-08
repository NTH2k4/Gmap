using Newtonsoft.Json;
using System.Reflection;
using static Gmap.Models.City;

namespace Gmap.Models
{
    internal class CityRepository
    {
        public GeoJson ReadCity()
        {
            /*string filePath = @"D:\Project VS\Gmap\Models\gadm41_VNM_1.json";*/
            /*string filePath = "Gmap.Models.gadm41_VNM_1.json";
            string geoJsonContent = File.ReadAllText(filePath);
            GeoJson geoJson = JsonConvert.DeserializeObject<GeoJson>(geoJsonContent);
            return geoJson;*/
            string resourceName = "Gmap.Models.gadm41_VNM_1.json";
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
