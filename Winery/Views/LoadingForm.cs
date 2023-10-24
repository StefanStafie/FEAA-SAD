using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Winery.Views
{
    public partial class LoadingForm : Form
    {
        private BackgroundWorker backgroundWorker;
        private Action task;
        private Action onTaskCompleted;
        public LoadingForm(Action task)
        {
            InitializeComponent();

            this.task = task;
            this.onTaskCompleted = null;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Execute the task on a separate thread.
            this.task.Invoke();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
            this.Close();
        }

        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}