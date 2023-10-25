using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Views;

namespace Winery
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.databaseOverviewTabControl.Dock = DockStyle.Fill;

        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.graphsTabControl.Dock = DockStyle.Fill;
            this.databaseOverviewTabControl.Visible = true;
            //this.databaseOverviewTabControl.Init(); 
        }

        private void ResetMenuItems()
        {
            foreach (ToolStripMenuItem item in this.menuStrip1.Items)
            {
                item.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ResetMenuItems();
            ((ToolStripMenuItem)sender).BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ResetViews();
            this.ChangeView((ToolStripMenuItem)sender);
        }

        private void ResetViews()
        {
            foreach (Control control in this.splitContainer2.Panel2.Controls)
            {
                control.Visible = false;
            }
        }

        private void ChangeView(ToolStripMenuItem sender)
        {
            switch (sender.Text)
            {
                case "Database Overview":
                    this.databaseOverviewTabControl.Visible = true;
                    break;

                case "Data Generator":
                    this.dataGeneratorPanel.Visible = true;
                    break;

                case "Graphs":
                    this.graphsTabControl.Visible = true;
                    break;

            }

        }
    }
}
