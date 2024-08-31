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
            splitContainerControl = new SplitContainer();
            btnActiveDrag = new Button();
            btnActiveMouseClick = new Button();
            btnChangeZoom = new Button();
            txtZoom = new TextBox();
            btnAddMarker = new Button();
            btnGoto = new Button();
            lbLongitude = new Label();
            txtLongitude = new TextBox();
            lbLatitude = new Label();
            txtLatitude = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).BeginInit();
            splitContainerControl.Panel1.SuspendLayout();
            splitContainerControl.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerControl
            // 
            splitContainerControl.Dock = DockStyle.Fill;
            splitContainerControl.Location = new Point(0, 0);
            splitContainerControl.Margin = new Padding(4);
            splitContainerControl.Name = "splitContainerControl";
            // 
            // splitContainerControl.Panel1
            // 
            splitContainerControl.Panel1.BackColor = SystemColors.ActiveCaptionText;
            splitContainerControl.Panel1.Controls.Add(btnActiveDrag);
            splitContainerControl.Panel1.Controls.Add(btnActiveMouseClick);
            splitContainerControl.Panel1.Controls.Add(btnChangeZoom);
            splitContainerControl.Panel1.Controls.Add(txtZoom);
            splitContainerControl.Panel1.Controls.Add(btnAddMarker);
            splitContainerControl.Panel1.Controls.Add(btnGoto);
            splitContainerControl.Panel1.Controls.Add(lbLongitude);
            splitContainerControl.Panel1.Controls.Add(txtLongitude);
            splitContainerControl.Panel1.Controls.Add(lbLatitude);
            splitContainerControl.Panel1.Controls.Add(txtLatitude);
            splitContainerControl.Size = new Size(1264, 681);
            splitContainerControl.SplitterDistance = 420;
            splitContainerControl.SplitterWidth = 6;
            splitContainerControl.TabIndex = 0;
            // 
            // btnActiveDrag
            // 
            btnActiveDrag.Location = new Point(50, 595);
            btnActiveDrag.Name = "btnActiveDrag";
            btnActiveDrag.Size = new Size(151, 56);
            btnActiveDrag.TabIndex = 9;
            btnActiveDrag.Text = "Active Drag";
            btnActiveDrag.UseVisualStyleBackColor = true;
            btnActiveDrag.Click += btnActiveDrag_Click;
            // 
            // btnActiveMouseClick
            // 
            btnActiveMouseClick.Location = new Point(209, 595);
            btnActiveMouseClick.Name = "btnActiveMouseClick";
            btnActiveMouseClick.Size = new Size(151, 56);
            btnActiveMouseClick.TabIndex = 8;
            btnActiveMouseClick.Text = "Active Mouse Click";
            btnActiveMouseClick.UseVisualStyleBackColor = true;
            btnActiveMouseClick.Click += btnActiveMouseClick_Click;
            // 
            // btnChangeZoom
            // 
            btnChangeZoom.Location = new Point(209, 269);
            btnChangeZoom.Name = "btnChangeZoom";
            btnChangeZoom.Size = new Size(151, 29);
            btnChangeZoom.TabIndex = 7;
            btnChangeZoom.Text = "Change Zoom";
            btnChangeZoom.UseVisualStyleBackColor = true;
            btnChangeZoom.Click += btnChangeZoom_Click;
            // 
            // txtZoom
            // 
            txtZoom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtZoom.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtZoom.Location = new Point(50, 271);
            txtZoom.Margin = new Padding(4);
            txtZoom.Name = "txtZoom";
            txtZoom.Size = new Size(151, 27);
            txtZoom.TabIndex = 6;
            // 
            // btnAddMarker
            // 
            btnAddMarker.Location = new Point(209, 168);
            btnAddMarker.Name = "btnAddMarker";
            btnAddMarker.Size = new Size(151, 32);
            btnAddMarker.TabIndex = 5;
            btnAddMarker.Text = "Add Marker";
            btnAddMarker.UseVisualStyleBackColor = true;
            btnAddMarker.Click += btnAddMarker_Click;
            // 
            // btnGoto
            // 
            btnGoto.Location = new Point(50, 168);
            btnGoto.Name = "btnGoto";
            btnGoto.Size = new Size(151, 32);
            btnGoto.TabIndex = 4;
            btnGoto.Text = "Go to coordinate";
            btnGoto.UseVisualStyleBackColor = true;
            btnGoto.Click += btnGoto_Click;
            // 
            // lbLongitude
            // 
            lbLongitude.AutoSize = true;
            lbLongitude.ForeColor = SystemColors.Control;
            lbLongitude.Location = new Point(50, 113);
            lbLongitude.Margin = new Padding(4, 0, 4, 0);
            lbLongitude.Name = "lbLongitude";
            lbLongitude.Size = new Size(82, 22);
            lbLongitude.TabIndex = 3;
            lbLongitude.Text = "Tọa độ y: ";
            // 
            // txtLongitude
            // 
            txtLongitude.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLongitude.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLongitude.Location = new Point(140, 113);
            txtLongitude.Margin = new Padding(4);
            txtLongitude.Name = "txtLongitude";
            txtLongitude.Size = new Size(220, 27);
            txtLongitude.TabIndex = 2;
            // 
            // lbLatitude
            // 
            lbLatitude.AutoSize = true;
            lbLatitude.ForeColor = SystemColors.Control;
            lbLatitude.Location = new Point(50, 66);
            lbLatitude.Margin = new Padding(4, 0, 4, 0);
            lbLatitude.Name = "lbLatitude";
            lbLatitude.Size = new Size(82, 22);
            lbLatitude.TabIndex = 1;
            lbLatitude.Text = "Tọa độ x: ";
            // 
            // txtLatitude
            // 
            txtLatitude.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLatitude.Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLatitude.Location = new Point(140, 66);
            txtLatitude.Margin = new Padding(4);
            txtLatitude.Name = "txtLatitude";
            txtLatitude.Size = new Size(220, 27);
            txtLatitude.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitContainerControl);
            Font = new Font("Montserrat", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Main";
            Text = "Gmap";
            splitContainerControl.Panel1.ResumeLayout(false);
            splitContainerControl.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).EndInit();
            splitContainerControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerControl;
        private TextBox txtLatitude;
        private Label lbLongitude;
        private TextBox txtLongitude;
        private Label lbLatitude;
        private Button btnAddMarker;
        private Button btnGoto;
        private Button btnActiveDrag;
        private Button btnActiveMouseClick;
        private Button btnChangeZoom;
        private TextBox txtZoom;
    }
}
