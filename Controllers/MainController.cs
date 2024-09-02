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
        private readonly GMapControl _mainControl;
        private readonly CityRepository _cityReader;
        private readonly RoadRepository _roadReader;

        public MainController(GMapControl mainControl)
        {
            _mainControl = mainControl;
            _cityReader = new CityRepository();
            _roadReader = new RoadRepository();
        }

        public void LoadGeoJsonCity()
        {
            City.GeoJson geoJson = _cityReader.ReadCity();

            foreach (var feature in geoJson.features)
            {
                GMapOverlay overlay = new GMapOverlay("polygons");
                foreach (var polygonCoordinates in feature.geometry.coordinates)
                {
                    foreach (var ringCoordinates in polygonCoordinates)
                    {
                        List<PointLatLng> points = new List<PointLatLng>();
                        foreach (var coordinate in ringCoordinates)
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

                        overlay.Polygons.Add(polygon);
                    }
                }
                _mainControl.Overlays.Add(overlay);
            }
            _mainControl.ZoomAndCenterMarkers("polygons");
        }


        /*public void LoadGeoJsonRoad()
        {
            Road.GeoJson geoJson = _roadReader.ReadRoad();

            foreach (var feature in geoJson.features)
            {
                GMapOverlay overlay = new GMapOverlay("routes");
                foreach (var routeCoordinates in feature.geometry.coordinates)
                {
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (var coordinate in routeCoordinates)
                    {
                        double x = coordinate[1];
                        double y = coordinate[0];
                        points.Add(new PointLatLng(x, y));
                    }

                    GMapRoute route = new GMapRoute(points, feature.properties.name)
                    {
                        Stroke = new Pen(Color.Blue, 2)
                    };

                    overlay.Routes.Add(route);
                }
            }
            _mainControl.ZoomAndCenterRoutes("routes");
        }*/

        public void LoadGeoJsonRoad()
        {
            Road.GeoJson geoJson = _roadReader.ReadRoad();

            foreach (var feature in geoJson.features)
            {
                GMapOverlay overlay = new GMapOverlay("routes");

                foreach (var lineStringCoordinates in feature.geometry.coordinates)
                {
                    List<PointLatLng> points = new List<PointLatLng>();
                    foreach (var coordinate in lineStringCoordinates)
                    {
                        double x = coordinate[1];
                        double y = coordinate[0];
                        points.Add(new PointLatLng(x, y));
                    }

                    GMapRoute route = new GMapRoute(points, feature.properties.name)
                    {
                        Stroke = new Pen(Color.Yellow, 2)
                    };

                    overlay.Routes.Add(route);
                }
                _mainControl.Overlays.Add(overlay);
            }

            _mainControl.ZoomAndCenterRoutes("routes");
        }

    }
}
