using Gmap.Models;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

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

        /*public void LoadGeoJsonCity()
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
        }*/

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
                        double lat = 0, lng = 0;
                        int count = 0;
                        foreach (var coordinate in ringCoordinates)
                        {
                            double x = coordinate[1];
                            double y = coordinate[0];
                            lat += x;
                            lng += y;
                            count++;
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

            // Thêm sự kiện MouseDown vào GMapControl
            _mainControl.MouseDown += new MouseEventHandler(MainControl_MouseDown);
        }

        // Xử lý sự kiện MouseDown
        private void MainControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = _mainControl.FromLocalToLatLng(e.X, e.Y);

                foreach (var overlay in _mainControl.Overlays)
                {
                    foreach (var polygon in overlay.Polygons)
                    {
                        if (polygon.IsInside(point))
                        {
                            // Tạo chuỗi chứa các thông tin bổ sung
                            var feature = _cityReader.ReadCity().features.FirstOrDefault(f => f.properties.NAME_1 == polygon.Name);
                            if (feature != null)
                            {
                                string info = $"Tên: {feature.properties.NAME_1}\n" +
                                              $"GID_1: {feature.properties.GID_1}\n" +
                                              $"GID_0: {feature.properties.GID_0}\n" +
                                              $"Quốc gia: {feature.properties.COUNTRY}\n" +
                                              $"Tên khác: {feature.properties.VARNAME_1}\n" +
                                              $"Loại: {feature.properties.TYPE_1}\n" +
                                              $"Loại (tiếng Anh): {feature.properties.ENGTYPE_1}\n" +
                                              $"Mã ISO: {feature.properties.ISO_1}";

                                MessageBox.Show(info, "Thông tin thành phố", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }
                    }
                }
            }
        }

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
