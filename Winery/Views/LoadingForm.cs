using System;
using System.ComponentModel;
using System.Windows.Forms;


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
            onTaskCompleted = null;

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Execute the task on a separate thread.
            task.Invoke();
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }

        private void LoadingForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}