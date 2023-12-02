using System;
using System.Drawing;
using System.IO;
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
            Directory.CreateDirectory($"{Application.StartupPath}\\Exports");
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartLoadingDialog();
            databaseOverviewTabControl.Dock = DockStyle.Fill;
            graphsTabControl.Dock = DockStyle.Fill;
            graphsTabControl2.Dock = DockStyle.Fill;
            graphsTabControl3.Dock = DockStyle.Fill;
            databaseOverviewTabControl.Visible = true;
            databaseOverviewTabControl.Init();
            CloseLoadingDialog();
        }

        private void ResetMenuItems()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.ActiveCaption;
            }
        }

        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMenuItems();
            ((ToolStripMenuItem)sender).BackColor = SystemColors.MenuHighlight;
            ResetViews();
            ChangeView((ToolStripMenuItem)sender);
        }

        private void ResetViews()
        {
            foreach (Control control in splitContainer2.Panel2.Controls)
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
                    databaseOverviewTabControl.Visible = true;
                    break;

                case "Data Generator":
                    dataGeneratorPanel.Visible = true;
                    break;

                case "Graphs 1":
                    graphsTabControl.Visible = true;
                    break;
                
                case "Graphs 2":
                    graphsTabControl2.Visible = true;
                    break;
                
                case "Graphs 3":
                    graphsTabControl3.LoadedTreeview1 = true;
                    graphsTabControl3.Visible = true;
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
