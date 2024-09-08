using Gmap.Controllers;
using Gmap.Models;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Xml.Serialization;
using static Gmap.Controllers.MainController;

namespace Gmap
{
    public partial class Main : Form
    {
        public GMap.NET.WindowsForms.GMapControl gMap { get; private set; }
        private ToolTip toolTip = new ToolTip();
        public Main()
        {
            InitializeComponent();
            InitializeMap();
        }
        private MainController _mainController;
        private void InitializeMap()
        {
            gMap = new GMap.NET.WindowsForms.GMapControl();
            gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMap.Dock = DockStyle.Fill;
            /*gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;*/
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.ShowCenter = false;
            gMap.MinZoom = 1;
            gMap.MaxZoom = 20;
            gMap.Zoom = 5;
            gMap.SetPositionByKeywords("Hanoi, Vietnam");
            gMap.CanDragMap = false;
            panelMap.Controls.Add(gMap);

            _mainController = new MainController(gMap);
            CityRepository geoJsonReader = new CityRepository();
            _mainController.LoadGeoJsonCity();

            RoadRepository geoRepository = new RoadRepository();
            _mainController.LoadGeoJsonRoad();
        }

        private void cancelActiveDrag()
        {
            gMap.CanDragMap = false;
            btnActiveDrag.BackColor = Color.White;
        }

        private void cancelActiveMouseClick()
        {
            gMap.MouseClick -= gMap_MouseClick;
            _mainController.cancelInfoCity();
            btnActiveMouseClick.BackColor = Color.White;
        }

        private void cancelAddMaker()
        {
            btnAddMarker.BackColor = Color.White;
            isAddMarkerActive = false;
            btnClear.Visible = false;
            gMap.MouseClick -= gMap_MouseClickForPath;
        }

        private void cancelActiveMeasure()
        {
            gMap.MouseClick -= gMap_MouseClickForMeasure;
            btnMeasure.BackColor = Color.White;
            btnClear.Visible = false;
        }

        private void btnActiveDrag_Click(object sender, EventArgs e)
        {
            if (btnActiveDrag.BackColor == Color.White)
            {
                gMap.CanDragMap = true;
                gMap.DragButton = MouseButtons.Left;
                btnActiveDrag.BackColor = Color.Cyan;
                if (btnActiveMouseClick.BackColor == Color.Cyan)
                {
                    cancelActiveMouseClick();
                }
                if (btnAddMarker.BackColor == Color.Cyan)
                {
                    cancelAddMaker();
                }
                if (btnMeasure.BackColor == Color.Cyan)
                {
                    cancelActiveMeasure();
                }
            }
            else
            {
                cancelActiveDrag();
            }
        }

        private void btnActiveMouseClick_Click(object sender, EventArgs e)
        {
            if (btnActiveMouseClick.BackColor == Color.White)
            {
                gMap.MouseClick += gMap_MouseClick;
                _mainController.infoCity();
                btnActiveMouseClick.BackColor = Color.Cyan;
                if (btnActiveDrag.BackColor == Color.Cyan)
                {
                    cancelActiveDrag();
                }
                if (btnAddMarker.BackColor == Color.Cyan)
                {
                    cancelAddMaker();
                }
                if (btnMeasure.BackColor == Color.Cyan)
                {
                    cancelActiveMeasure();
                }
            }
            else
            {
                cancelActiveMouseClick();
            }
        }

        private void gMap_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointLatLng point = gMap.FromLocalToLatLng(e.X, e.Y);
                string coordinates = $"X: {point.Lat}\nY: {point.Lng}";
                // Display ToolTip at mouse cursor position
                toolTip.Show(coordinates, gMap, e.Location.X + 10, e.Location.Y + 10, 3000);
            }
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (btnMeasure.BackColor == Color.White)
            {
                btnMeasure.BackColor = Color.Cyan;
                isAddMarkerActive = true;
                btnClear.Visible = true;
                gMap.MouseClick += gMap_MouseClickForMeasure;
                if (btnActiveDrag.BackColor == Color.Cyan)
                {
                    cancelActiveDrag();
                }
                if (btnActiveMouseClick.BackColor == Color.Cyan)
                {
                    cancelActiveMouseClick();
                }
                if (btnAddMarker.BackColor == Color.Cyan)
                {
                    cancelAddMaker();
                }
            }
            else
            {
                cancelActiveMeasure();
            }
        }

        private void gMap_MouseClickForMeasure(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isAddMarkerActive)
            {
                PointLatLng pointer = gMap.FromLocalToLatLng(e.X, e.Y);
                selectedPoints.Add(pointer);
                GMarkerGoogle marker = new GMarkerGoogle(pointer, GMarkerGoogleType.green_dot);
                markersOverlay.Markers.Add(marker);
                gMap.Overlays.Add(markersOverlay);
                if (selectedPoints.Count == 2)
                {
                    double distance = CalculateDistance(selectedPoints[0], selectedPoints[1]);
                    MessageBox.Show($"Khoảng cách giữa 2 vị trí là: {distance} km");
                    markersOverlay.Markers.Clear();
                    selectedPoints.Clear();
                    gMap.Refresh();
                }
            }
        }

        private double CalculateDistance(PointLatLng point1, PointLatLng point2)
        {
            var R = 6371;
            var lat = (point2.Lat - point1.Lat) * Math.PI / 180.0;
            var lng = (point2.Lng - point1.Lng) * Math.PI / 180.0;
            var h1 = Math.Sin(lat / 2) * Math.Sin(lat / 2) + Math.Cos(point1.Lat * Math.PI / 180.0) * Math.Cos(point2.Lat * Math.PI / 180.0) * Math.Sin(lng / 2) * Math.Sin(lng / 2);
            var h2 = 2 * Math.Asin(Math.Sqrt(h1));
            return R * h2;
        }

        private void btnAddMarker_Click(object sender, EventArgs e)
        {
            if (btnAddMarker.BackColor == Color.White)
            {
                btnAddMarker.BackColor = Color.Cyan;
                isAddMarkerActive = true;
                btnClear.Visible = true;
                gMap.MouseClick += gMap_MouseClickForPath;
                if (btnActiveDrag.BackColor == Color.Cyan)
                {
                    cancelActiveDrag();
                }
                if (btnActiveMouseClick.BackColor == Color.Cyan)
                {
                    cancelActiveMouseClick();
                }
                if (btnMeasure.BackColor == Color.Cyan)
                {
                    cancelActiveMeasure();
                }
            }
            else
            {
                cancelAddMaker();
            }
        }

        private bool isAddMarkerActive = false;
        private List<PointLatLng> selectedPoints = new List<PointLatLng>();
        private GMapOverlay markersOverlay = new GMapOverlay("markers");
        /*private void gMap_MouseClickForPath(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isAddMarkerActive)
            {
                PointLatLng pointer = gMap.FromLocalToLatLng(e.X, e.Y);
                selectedPoints.Add(pointer);
                GMarkerGoogle marker = new GMarkerGoogle(pointer, GMarkerGoogleType.red_dot);
                markersOverlay.Markers.Add(marker);
                gMap.Overlays.Add(markersOverlay);
                if (selectedPoints.Count == 2)
                {
                    var route = GoogleMapProvider.Instance.GetRoute(selectedPoints[0], selectedPoints[1], false, false, 14);
                    var routeOverlay = new GMapRoute(route.Points, "My route");
                    var routeOverlayLayer = new GMapOverlay("route");
                    routeOverlay.Stroke = new Pen(Color.Red, 3);
                    routeOverlayLayer.Routes.Add(routeOverlay);
                    gMap.Overlays.Add(routeOverlayLayer);
                }
            }
        }*/

        private void gMap_MouseClickForPath(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && isAddMarkerActive)
            {
                PointLatLng pointer = gMap.FromLocalToLatLng(e.X, e.Y);
                _mainController.AddMarker(pointer);

                if (_mainController.SelectedPointsCount == 2)
                {
                    /*btnFindPath.Visible = true;*/
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _mainController.ClearMarkers();
        }
        private void btnFindPath_Click(object sender, EventArgs e)
        {
            _mainController.FindShortestRoute(txtCityStart.Text, txtCityEnd.Text);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String cityName = txtSearch.Text;
            if (_mainController.SearchCity(cityName) != null)
            {
                MessageBox.Show("Tìm thấy thành phố " + cityName);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thành phố " + cityName);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            gMap.Zoom += 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            gMap.Zoom -= 1;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelPath.Visible)
            {
                panelPath.Visible = false;
            }
            else
            {
                panelPath.Visible = true;
            }
        }

        private void btnClearPath_Click(object sender, EventArgs e)
        {
            _mainController.ClearMarkers();
        }
    }
}
