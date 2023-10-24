namespace Winery
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGeneratorPanel = new Winery.Views.DataGeneratorPanell();
            this.databaseOverviewTabControl = new Winery.Views.DatabaseOverviewTabControl();
            this.graphsTabControl = new Winery.Views.GraphsTabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ineToolStripMenuItem,
            this.twoToolStripMenuItem,
            this.threeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(1286, 39);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ineToolStripMenuItem
            // 
            this.ineToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ineToolStripMenuItem.Name = "ineToolStripMenuItem";
            this.ineToolStripMenuItem.Size = new System.Drawing.Size(119, 39);
            this.ineToolStripMenuItem.Text = "Database Overview";
            this.ineToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // twoToolStripMenuItem
            // 
            this.twoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.twoToolStripMenuItem.Name = "twoToolStripMenuItem";
            this.twoToolStripMenuItem.Size = new System.Drawing.Size(98, 39);
            this.twoToolStripMenuItem.Text = "Data Generator";
            this.twoToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // threeToolStripMenuItem
            // 
            this.threeToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.threeToolStripMenuItem.Name = "threeToolStripMenuItem";
            this.threeToolStripMenuItem.Size = new System.Drawing.Size(56, 39);
            this.threeToolStripMenuItem.Text = "Graphs";
            this.threeToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 36, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(20, 0, 4, 6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.splitContainer2.Panel2.Controls.Add(this.graphsTabControl);
            this.splitContainer2.Panel2.Controls.Add(this.dataGeneratorPanel);
            this.splitContainer2.Panel2.Controls.Add(this.databaseOverviewTabControl);
            this.splitContainer2.Size = new System.Drawing.Size(1310, 477);
            this.splitContainer2.SplitterDistance = 45;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 2;
            // 
            // dataGeneratorPanel
            // 
            this.dataGeneratorPanel.Location = new System.Drawing.Point(3, 3);
            this.dataGeneratorPanel.Name = "dataGeneratorPanel";
            this.dataGeneratorPanel.Size = new System.Drawing.Size(586, 309);
            this.dataGeneratorPanel.TabIndex = 35;
            this.dataGeneratorPanel.Visible = false;
            // 
            // databaseOverviewTabControl
            // 
            this.databaseOverviewTabControl.Location = new System.Drawing.Point(722, 38);
            this.databaseOverviewTabControl.Name = "databaseOverviewTabControl";
            this.databaseOverviewTabControl.Size = new System.Drawing.Size(309, 202);
            this.databaseOverviewTabControl.TabIndex = 34;
            this.databaseOverviewTabControl.Visible = false;
            // 
            // graphsTabControl
            // 
            this.graphsTabControl.Location = new System.Drawing.Point(655, 254);
            this.graphsTabControl.Name = "graphsTabControl";
            this.graphsTabControl.Size = new System.Drawing.Size(1252, 715);
            this.graphsTabControl.TabIndex = 36;
            this.graphsTabControl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1310, 477);
            this.Controls.Add(this.splitContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wine Decision System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem ineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threeToolStripMenuItem;
        private Views.DatabaseOverviewTabControl databaseOverviewTabControl;
        private Views.DataGeneratorPanell dataGeneratorPanel;
        private Views.GraphsTabControl graphsTabControl;
    }
}

