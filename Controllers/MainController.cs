using Gmap.Models;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Collections.Generic;
using System.Drawing;
using static Gmap.Models.City;

namespace Gmap.Controllers
{
    internal class MainController
    {
        /*private CityRepository cityRepository;
        private Main mainForm;
        private List<City> cities;

        public MainController(Main form)
        {
            cityRepository = new CityRepository();
            mainForm = form;
        }*/
        private readonly GMapControl _mainControl;
        private readonly CityRepository _geoJsonReader;

        public MainController(GMapControl mainControl)
        {
            _mainControl = mainControl;
            _geoJsonReader = new CityRepository();
        }

        public void LoadGeoJsonAndDraw()
        {
            GeoJson geoJson = _geoJsonReader.ReadGeoJson();

            foreach (var feature in geoJson.features)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var coordinate in feature.geometry.coordinates[0][0])
                {
                    double x = coordinate[1];
                    double y = coordinate[0];
                    points.Add(new PointLatLng(x, y));
                }

                GMapPolygon polygon = new GMapPolygon(points, feature.properties.NAME_1)
                {
                    Stroke = new Pen(Color.Red, 1),
                    Fill = new SolidBrush(Color.FromArgb(50, Color.Red))
                };

                GMapOverlay overlay = new GMapOverlay("polygons");
                overlay.Polygons.Add(polygon);
                _mainControl.Overlays.Add(overlay);
            }

            _mainControl.ZoomAndCenterMarkers("polygons");
        }
    }
}
