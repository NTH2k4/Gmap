using Gmap.Models;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Gmap.Controllers
{
    internal class MainController
    {
        private readonly GMapControl _mainControl;
        private readonly CityRepository _cityReader;
        private readonly RoadRepository _roadReader;

        private List<PointLatLng> selectedPoints = new List<PointLatLng>();
        private GMapOverlay markersOverlay = new GMapOverlay("markers");

        public MainController(GMapControl mainControl)
        {
            _mainControl = mainControl;
            _cityReader = new CityRepository();
            _roadReader = new RoadRepository();
        }

        public void LoadGeoJsonCity()
        {
            City.GeoJson geoJson = _cityReader.ReadCity();
            List<PointLatLng> allCenters = new List<PointLatLng>();

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

                        if (count > 0)
                        {
                            double centerLat = lat / count;
                            double centerLng = lng / count;
                            allCenters.Add(new PointLatLng(centerLat, centerLng));
                        }
                    }
                }
                _mainControl.Overlays.Add(overlay);
            }
            if (allCenters.Count > 0)
            {
                double totalLat = 0, totalLng = 0;
                foreach (var center in allCenters)
                {
                    totalLat += center.Lat;
                    totalLng += center.Lng;
                }
                double avgLat = totalLat / allCenters.Count;
                double avgLng = totalLng / allCenters.Count;
                PointLatLng mapCenter = new PointLatLng(avgLat, avgLng);
                _mainControl.Position = mapCenter;
            }
            _mainControl.ZoomAndCenterMarkers("polygons");

            /*// Thêm sự kiện MouseDown vào GMapControl
            _mainControl.MouseDown += new MouseEventHandler(MainControl_MouseDown);*/
        }

        public void infoCity()
        {
            // Thêm sự kiện MouseDown vào GMapControl
            _mainControl.MouseDown += new MouseEventHandler(MainControl_MouseDown);
        }

        //Hủy sự kiện MouseDown
        public void cancelInfoCity()
        {
            _mainControl.MouseDown -= new MouseEventHandler(MainControl_MouseDown);
        }
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

        private double GetDistance(PointLatLng point1, PointLatLng point2)
        {
            var d1 = point1.Lat * (Math.PI / 180.0);
            var num1 = point1.Lng * (Math.PI / 180.0);
            var d2 = point2.Lat * (Math.PI / 180.0);
            var num2 = point2.Lng * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3))) / 1000.0; // Distance in kilometers
        }

        public void AddMarker(PointLatLng point)
        {
            selectedPoints.Add(point);
            GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(marker);
            _mainControl.Overlays.Add(markersOverlay);
        }
        public void ClearMarkers()
        {
            selectedPoints.Clear();
            markersOverlay.Markers.Clear();
            _mainControl.Refresh();
        }

        public void FindRoute()
        {
            try
            {
                var route = GoogleMapProvider.Instance.GetRoute(selectedPoints[0], selectedPoints[1], false, false, 14);
                if (route != null)
                {
                    var routeOverlay = new GMapRoute(route.Points, "My route");
                    var routeOverlayLayer = new GMapOverlay("route");
                    routeOverlay.Stroke = new Pen(Color.Red, 3);
                    routeOverlayLayer.Routes.Add(routeOverlay);
                    _mainControl.Overlays.Add(routeOverlayLayer);
                    _mainControl.Refresh();
                    MessageBox.Show($"Khoảng cách: {route.Distance} km\nThời gian: {route.Duration} phút");
                }
                else
                {
                    MessageBox.Show("Không thể tìm thấy đường đi giữa hai điểm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm đường: {ex.Message}");
            }
        }

        public int SelectedPointsCount => selectedPoints.Count;

        /*public void SearchCity(string cityName)
        {
            City.GeoJson geoJson = _cityReader.ReadCity();
            var feature = geoJson.features.FirstOrDefault(f => f.properties.NAME_1.Equals(cityName, StringComparison.OrdinalIgnoreCase));
            if (feature != null)
            {
                var coordinates = feature.geometry.coordinates[0][0][0];
                var point = new PointLatLng(coordinates[1], coordinates[0]);
                _mainControl.Position = point;
                MessageBox.Show($"Tìm thấy thành phố: {cityName}");
            }
            else
            {
                MessageBox.Show($"Không tìm thấy thành phố: {cityName}");
            }
        }*/

        public void DrawRoute(PointLatLng start, PointLatLng end)
        {
            try
            {
                var route = GoogleMapProvider.Instance.GetRoute(start, end, false, false, 14);
                if (route != null)
                {
                    var routeOverlay = new GMapRoute(route.Points, "My route");
                    var routeOverlayLayer = new GMapOverlay("route");
                    routeOverlay.Stroke = new Pen(Color.Blue, 10);
                    routeOverlayLayer.Routes.Add(routeOverlay);
                    _mainControl.Overlays.Add(routeOverlayLayer);

                    // Thêm marker cho điểm bắt đầu
                    var startMarker = new GMarkerGoogle(start, GMarkerGoogleType.green_dot);
                    startMarker.ToolTipText = "Start";
                    routeOverlayLayer.Markers.Add(startMarker);

                    // Thêm marker cho điểm kết thúc
                    var endMarker = new GMarkerGoogle(end, GMarkerGoogleType.red_dot);
                    endMarker.ToolTipText = "End";
                    routeOverlayLayer.Markers.Add(endMarker);

                    _mainControl.Refresh();
                    MessageBox.Show($"Khoảng cách: {route.Distance} km\nThời gian: {route.Duration} phút");
                }
                else
                {
                    MessageBox.Show("Không thể tìm thấy đường đi giữa hai điểm.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm đường: {ex.Message}");
            }
        }


        public PointLatLng? GetCityCenter(string cityName)
        {
            return SearchCity(cityName);
        }

        public void FindShortestRoute(string cityStart, string cityEnd)
        {
            var pointStart = GetCityCenter(cityStart);
            var pointEnd = GetCityCenter(cityEnd);

            if (pointStart.HasValue && pointEnd.HasValue)
            {
                DrawRoute(pointStart.Value, pointEnd.Value);
            }
            else
            {
                MessageBox.Show("Không thể tìm thấy một hoặc cả hai thành phố.");
            }
        }


        public PointLatLng? SearchCity(string cityName)
        {
            City.GeoJson geoJson = _cityReader.ReadCity();
            var feature = geoJson.features.FirstOrDefault(f => f.properties.NAME_1.Equals(cityName, StringComparison.OrdinalIgnoreCase));
            if (feature != null)
            {
                var coordinates = feature.geometry.coordinates[0][0][0];
                var point = new PointLatLng(coordinates[1], coordinates[0]);
                _mainControl.Position = point;
                return point;
            }
            return null;
        }
    }
}

