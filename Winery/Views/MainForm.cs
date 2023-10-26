using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Views;

namespace Winery
{
    public partial class MainForm : Form
    {
        private static Thread loadingThread;
        public static LoadingFormPassive loadingFormPassive;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartLoadingDialog();
            this.databaseOverviewTabControl.Dock = DockStyle.Fill;
            this.graphsTabControl.Dock = DockStyle.Fill;
            this.graphsTabControl2.Dock = DockStyle.Fill;
            this.graphsTabControl3.Dock = DockStyle.Fill;
            this.databaseOverviewTabControl.Visible = true;
            this.databaseOverviewTabControl.Init();
            CloseLoadingDialog();
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
            ((ToolStripMenuItem)sender).BackColor = SystemColors.MenuHighlight;
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
            MainForm.StartLoadingDialog();

            switch (sender.Text)
            {
                case "Database Overview":
                    this.databaseOverviewTabControl.Visible = true;
                    break;

                case "Data Generator":
                    this.dataGeneratorPanel.Visible = true;
                    break;

                case "Graphs 1":
                    this.graphsTabControl.Visible = true;
                    break;
                case "Graphs 2":
                    this.graphsTabControl2.Visible = true;
                    break;
                case "Graphs 3":
                    this.graphsTabControl3.LoadedTreeview1 = true;  
                    this.graphsTabControl3.Visible = true;
                    break;
                case "Graphs 4":
                    //this.graphsTabControl.Visible = true;
                    break;
                case "Graphs 5":
                    //this.graphsTabControl.Visible = true;
                    break;
                case "Graphs 6":
                    //this.graphsTabControl.Visible = true;
                    break;

            }

            MainForm.CloseLoadingDialog();
        }

        public static void StartLoadingDialog()
        {
            try
            {
                loadingThread = new Thread(() =>
                {
                    try
                    {
                        MainForm.loadingFormPassive = new LoadingFormPassive();
                        loadingFormPassive?.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                });

                loadingThread.Start();
            }
            catch (Exception)
            {
                return;
            }
        }

        public static void CloseLoadingDialog()
        {
            try
            {
                while (!LoadingFormPassive.IsShown)
                {
                    Thread.Sleep(50);
                }

                WinformsHelper.InvokeIfRequired(
                   MainForm.loadingFormPassive,
                       () =>
                       {
                           MainForm.loadingFormPassive?.Close();
                       }
                   );

                loadingThread.Join();
                loadingThread = null;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
