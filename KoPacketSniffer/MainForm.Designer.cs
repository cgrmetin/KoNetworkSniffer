namespace KoPacketSniffer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startListeningToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopListeningToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.devicesComboBox = new System.Windows.Forms.ComboBox();
            this.gidenGroupBox = new System.Windows.Forms.GroupBox();
            this.gidenListView = new System.Windows.Forms.ListView();
            this.gelenGroupBox = new System.Windows.Forms.GroupBox();
            this.gelenListView = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gidenGroupBox.SuspendLayout();
            this.gelenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.devicesComboBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1112, 44);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startListeningToolStripButton,
            this.stopListeningToolStripButton,
            this.refreshToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(663, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startListeningToolStripButton
            // 
            this.startListeningToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startListeningToolStripButton.Image = global::KoPacketSniffer.Properties.Resources._60207_start_icon;
            this.startListeningToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startListeningToolStripButton.Name = "startListeningToolStripButton";
            this.startListeningToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.startListeningToolStripButton.Text = "toolStripButton1";
            this.startListeningToolStripButton.Click += new System.EventHandler(this.startListeningToolStripButton_Click);
            // 
            // stopListeningToolStripButton
            // 
            this.stopListeningToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopListeningToolStripButton.Image = global::KoPacketSniffer.Properties.Resources._60208_red_stop_icon;
            this.stopListeningToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopListeningToolStripButton.Name = "stopListeningToolStripButton";
            this.stopListeningToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopListeningToolStripButton.Text = "toolStripButton1";
            this.stopListeningToolStripButton.Click += new System.EventHandler(this.stopListeningToolStripButton_Click);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::KoPacketSniffer.Properties.Resources._8726304_refresh_icon;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "toolStripButton1";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // devicesComboBox
            // 
            this.devicesComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.devicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesComboBox.FormattingEnabled = true;
            this.devicesComboBox.Location = new System.Drawing.Point(3, 16);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(650, 21);
            this.devicesComboBox.TabIndex = 1;
            // 
            // gidenGroupBox
            // 
            this.gidenGroupBox.Controls.Add(this.gidenListView);
            this.gidenGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.gidenGroupBox.Location = new System.Drawing.Point(0, 44);
            this.gidenGroupBox.Name = "gidenGroupBox";
            this.gidenGroupBox.Size = new System.Drawing.Size(503, 636);
            this.gidenGroupBox.TabIndex = 1;
            this.gidenGroupBox.TabStop = false;
            this.gidenGroupBox.Text = "Giden Paketler";
            // 
            // gidenListView
            // 
            this.gidenListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gidenListView.HideSelection = false;
            this.gidenListView.Location = new System.Drawing.Point(3, 16);
            this.gidenListView.Name = "gidenListView";
            this.gidenListView.Size = new System.Drawing.Size(497, 617);
            this.gidenListView.TabIndex = 0;
            this.gidenListView.UseCompatibleStateImageBehavior = false;
            // 
            // gelenGroupBox
            // 
            this.gelenGroupBox.Controls.Add(this.gelenListView);
            this.gelenGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gelenGroupBox.Location = new System.Drawing.Point(503, 44);
            this.gelenGroupBox.Name = "gelenGroupBox";
            this.gelenGroupBox.Size = new System.Drawing.Size(609, 636);
            this.gelenGroupBox.TabIndex = 2;
            this.gelenGroupBox.TabStop = false;
            this.gelenGroupBox.Text = "Gelen Paketler";
            // 
            // gelenListView
            // 
            this.gelenListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gelenListView.HideSelection = false;
            this.gelenListView.Location = new System.Drawing.Point(3, 16);
            this.gelenListView.Name = "gelenListView";
            this.gelenListView.Size = new System.Drawing.Size(603, 617);
            this.gelenListView.TabIndex = 0;
            this.gelenListView.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 680);
            this.Controls.Add(this.gelenGroupBox);
            this.Controls.Add(this.gidenGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Ko Sniffer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gidenGroupBox.ResumeLayout(false);
            this.gelenGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startListeningToolStripButton;
        private System.Windows.Forms.ToolStripButton stopListeningToolStripButton;
        private System.Windows.Forms.GroupBox gidenGroupBox;
        private System.Windows.Forms.ListView gidenListView;
        private System.Windows.Forms.GroupBox gelenGroupBox;
        private System.Windows.Forms.ListView gelenListView;
        private System.Windows.Forms.ComboBox devicesComboBox;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
    }
}

