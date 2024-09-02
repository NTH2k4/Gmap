﻿using System;
using Newtonsoft.Json;
using static Gmap.Models.Road;

namespace Gmap.Models
{
    internal class RoadRepository
    {
        public GeoJson ReadRoad()
        {
            string filePath = @"D:\Project VS\Gmap\Models\giaothong.geojson";
            string geoJsonContent = File.ReadAllText(filePath);
            GeoJson geoJson = JsonConvert.DeserializeObject<GeoJson>(geoJsonContent);
            return geoJson;
        }
    }
}