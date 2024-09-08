namespace Gmap
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelControl = new Panel();
            btnPlus = new Button();
            btnMinus = new Button();
            btnActiveDrag = new Button();
            btnAddMarker = new Button();
            btnMeasure = new Button();
            btnActiveMouseClick = new Button();
            panelMap = new Panel();
            panelPath = new Panel();
            btnClearPath = new Button();
            lbCityEnd = new Label();
            lbCityStart = new Label();
            txtCityEnd = new TextBox();
            txtCityStart = new TextBox();
            btnFindPath = new Button();
            btnMenu = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panelControl.SuspendLayout();
            panelMap.SuspendLayout();
            panelPath.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl
            // 
            panelControl.Anchor = AnchorStyles.Bottom;
            panelControl.BackColor = Color.DimGray;
            panelControl.Controls.Add(btnPlus);
            panelControl.Controls.Add(btnMinus);
            panelControl.Controls.Add(btnActiveDrag);
            panelControl.Controls.Add(btnAddMarker);
            panelControl.Controls.Add(btnMeasure);
            panelControl.Controls.Add(btnActiveMouseClick);
            panelControl.Location = new Point(500, 621);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(264, 48);
            panelControl.TabIndex = 14;
            // 
            // btnPlus
            // 
            btnPlus.Image = Properties.Resources.plus;
            btnPlus.Location = new Point(177, 5);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(37, 37);
            btnPlus.TabIndex = 6;
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnPlus_Click;
            // 
            // btnMinus
            // 
            btnMinus.Image = Properties.Resources.minus_sign;
            btnMinus.Location = new Point(220, 5);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(37, 37);
            btnMinus.TabIndex = 7;
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnMinus_Click;
            // 
            // btnActiveDrag
            // 
            btnActiveDrag.BackColor = Color.White;
            btnActiveDrag.Image = Properties.Resources.mouse;
            btnActiveDrag.Location = new Point(5, 5);
            btnActiveDrag.Name = "btnActiveDrag";
            btnActiveDrag.Size = new Size(37, 37);
            btnActiveDrag.TabIndex = 2;
            btnActiveDrag.UseVisualStyleBackColor = false;
            btnActiveDrag.Click += btnActiveDrag_Click;
            // 
            // btnAddMarker
            // 
            btnAddMarker.BackColor = Color.White;
            btnAddMarker.Image = Properties.Resources.location;
            btnAddMarker.Location = new Point(134, 5);
            btnAddMarker.Name = "btnAddMarker";
            btnAddMarker.Size = new Size(37, 37);
            btnAddMarker.TabIndex = 5;
            btnAddMarker.UseVisualStyleBackColor = false;
            btnAddMarker.Click += btnAddMarker_Click;
            // 
            // btnMeasure
            // 
            btnMeasure.BackColor = Color.White;
            btnMeasure.Image = Properties.Resources.measure;
            btnMeasure.Location = new Point(91, 5);
            btnMeasure.Name = "btnMeasure";
            btnMeasure.Size = new Size(37, 37);
            btnMeasure.TabIndex = 4;
            btnMeasure.UseVisualStyleBackColor = false;
            btnMeasure.Click += btnMeasure_Click;
            // 
            // btnActiveMouseClick
            // 
            btnActiveMouseClick.BackColor = Color.White;
            btnActiveMouseClick.Image = Properties.Resources.hand_pointer;
            btnActiveMouseClick.Location = new Point(48, 5);
            btnActiveMouseClick.Name = "btnActiveMouseClick";
            btnActiveMouseClick.Size = new Size(37, 37);
            btnActiveMouseClick.TabIndex = 3;
            btnActiveMouseClick.UseVisualStyleBackColor = false;
            btnActiveMouseClick.Click += btnActiveMouseClick_Click;
            // 
            // panelMap
            // 
            panelMap.Controls.Add(panelPath);
            panelMap.Controls.Add(btnMenu);
            panelMap.Controls.Add(btnClear);
            panelMap.Controls.Add(btnSearch);
            panelMap.Controls.Add(txtSearch);
            panelMap.Controls.Add(panelControl);
            panelMap.Dock = DockStyle.Fill;
            panelMap.Location = new Point(0, 0);
            panelMap.Name = "panelMap";
            panelMap.Size = new Size(1264, 681);
            panelMap.TabIndex = 15;
            // 
            // panelPath
            // 
            panelPath.Controls.Add(btnClearPath);
            panelPath.Controls.Add(lbCityEnd);
            panelPath.Controls.Add(lbCityStart);
            panelPath.Controls.Add(txtCityEnd);
            panelPath.Controls.Add(txtCityStart);
            panelPath.Controls.Add(btnFindPath);
            panelPath.Location = new Point(12, 68);
            panelPath.Name = "panelPath";
            panelPath.Size = new Size(290, 257);
            panelPath.TabIndex = 19;
            panelPath.Visible = false;
            // 
            // btnClearPath
            // 
            btnClearPath.Anchor = AnchorStyles.Bottom;
            btnClearPath.Location = new Point(164, 201);
            btnClearPath.Name = "btnClearPath";
            btnClearPath.Size = new Size(113, 31);
            btnClearPath.TabIndex = 20;
            btnClearPath.Text = "Clear";
            btnClearPath.UseVisualStyleBackColor = true;
            btnClearPath.Click += btnClearPath_Click;
            // 
            // lbCityEnd
            // 
            lbCityEnd.AutoSize = true;
            lbCityEnd.Location = new Point(22, 102);
            lbCityEnd.Name = "lbCityEnd";
            lbCityEnd.Size = new Size(77, 22);
            lbCityEnd.TabIndex = 20;
            lbCityEnd.Text = "City end";
            // 
            // lbCityStart
            // 
            lbCityStart.AutoSize = true;
            lbCityStart.Location = new Point(22, 13);
            lbCityStart.Name = "lbCityStart";
            lbCityStart.Size = new Size(80, 22);
            lbCityStart.TabIndex = 19;
            lbCityStart.Text = "City start";
            // 
            // txtCityEnd
            // 
            txtCityEnd.Anchor = AnchorStyles.Top;
            txtCityEnd.BackColor = Color.White;
            txtCityEnd.Location = new Point(17, 137);
            txtCityEnd.Name = "txtCityEnd";
            txtCityEnd.Size = new Size(260, 27);
            txtCityEnd.TabIndex = 18;
            // 
            // txtCityStart
            // 
            txtCityStart.Anchor = AnchorStyles.Top;
            txtCityStart.BackColor = Color.White;
            txtCityStart.Location = new Point(17, 50);
            txtCityStart.Name = "txtCityStart";
            txtCityStart.Size = new Size(260, 27);
            txtCityStart.TabIndex = 17;
            // 
            // btnFindPath
            // 
            btnFindPath.Location = new Point(17, 201);
            btnFindPath.Name = "btnFindPath";
            btnFindPath.Size = new Size(113, 31);
            btnFindPath.TabIndex = 16;
            btnFindPath.Text = "Find path";
            btnFindPath.UseVisualStyleBackColor = true;
            btnFindPath.Click += btnFindPath_Click;
            // 
            // btnMenu
            // 
            btnMenu.Image = Properties.Resources.menu;
            btnMenu.Location = new Point(12, 12);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(50, 50);
            btnMenu.TabIndex = 18;
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom;
            btnClear.Location = new Point(596, 584);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 31);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Visible = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top;
            btnSearch.BackColor = Color.White;
            btnSearch.Image = Properties.Resources.loupe;
            btnSearch.Location = new Point(911, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(37, 37);
            btnSearch.TabIndex = 8;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top;
            txtSearch.BackColor = Color.White;
            txtSearch.Location = new Point(317, 23);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(588, 27);
            txtSearch.TabIndex = 1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelMap);
            Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Main";
            Text = "Gmap";
            panelControl.ResumeLayout(false);
            panelMap.ResumeLayout(false);
            panelMap.PerformLayout();
            panelPath.ResumeLayout(false);
            panelPath.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelControl;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnActiveDrag;
        private Button btnAddMarker;
        private Button btnMeasure;
        private Button btnActiveMouseClick;
        private Panel panelMap;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClear;
        private Button btnFindPath;
        private Button btnMenu;
        private TextBox txtCityStart;
        private Panel panelPath;
        private Label lbCityEnd;
        private Label lbCityStart;
        private TextBox txtCityEnd;
        private Button btnClearPath;
    }
}
