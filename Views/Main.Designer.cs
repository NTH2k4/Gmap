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
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).BeginInit();
            splitContainerControl.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerControl
            // 
            splitContainerControl.Dock = DockStyle.Fill;
            splitContainerControl.Location = new Point(0, 0);
            splitContainerControl.Name = "splitContainerControl";
            splitContainerControl.Size = new Size(800, 450);
            splitContainerControl.SplitterDistance = 266;
            splitContainerControl.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainerControl);
            Name = "Main";
            Text = "Gmap";
            ((System.ComponentModel.ISupportInitialize)splitContainerControl).EndInit();
            splitContainerControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerControl;
    }
}
