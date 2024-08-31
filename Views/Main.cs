using GMap.NET;
using GMap.NET.WindowsForms;
using System;
namespace Gmap
{
    public partial class Main : Form
    {
        GMap.NET.WindowsForms.GMapControl gMap;

        public Main()
        {
            InitializeComponent();
            gMap = new GMap.NET.WindowsForms.GMapControl();
            gMap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMap.Dock = DockStyle.Fill;
            gMap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gMap.ShowCenter = false;
            gMap.MinZoom = 1;
            gMap.MaxZoom = 20;
            gMap.Position = new PointLatLng(21.5, 105.8);
            gMap.Zoom = 9;
            gMap.OnMapZoomChanged += new MapZoomChanged(onMapZoomChanged);
            splitContainerControl.Panel2.Controls.Add(gMap);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            gMap.Position = new PointLatLng(Convert.ToDouble(txtLatitude.Text), Convert.ToDouble(txtLongitude.Text));
            gMap.Zoom = 9;
            gMap.Update();
            gMap.Refresh();
        }

        private void btnChangeZoom_Click(object sender, EventArgs e)
        {
            gMap.Zoom = Convert.ToInt32(txtZoom.Text);
            gMap.Update();
            gMap.Refresh();
        }

        private void btnActiveDrag_Click(object sender, EventArgs e)
        {
            gMap.DragButton = MouseButtons.Left;
        }

        private void btnActiveMouseClick_Click(object sender, EventArgs e)
        {
            if (btnActiveMouseClick.Text == "Active Mouse Click")
            {
                gMap.MouseClick += gMap_MouseClick;
                btnActiveMouseClick.Text = "Deactive Mouse Click";
            }
            else
            {
                gMap.MouseClick -= gMap_MouseClick;
                btnActiveMouseClick.Text = "Active Mouse Click";
            }
        }

        private void gMap_MouseClick(object? sender, MouseEventArgs e)
        {
            MessageBox.Show("Latitude: " + gMap.FromLocalToLatLng(e.X, e.Y).Lat + " Longitude: " + gMap.FromLocalToLatLng(e.X, e.Y).Lng);
        }

        private void btnAddMarker_Click(object sender, EventArgs e)
        {
            // Layer count is just a variable to add new Overlays with different names
            var makersOverlay = new GMap.NET.WindowsForms.GMapOverlay("markers" + gMap.Overlays.Count);

            var marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(
                new PointLatLng(Convert.ToDouble(txtLatitude.Text), Convert.ToDouble(txtLongitude.Text)),
                GMap.NET.WindowsForms.Markers.GMarkerGoogleType.red_small);
            makersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(makersOverlay);
        }

        private void onMapZoomChanged()
        {
            txtZoom.Text = gMap.Zoom.ToString();
        }
    }
}
