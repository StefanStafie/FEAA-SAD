using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Winery.Views
{
    public partial class WineControl : UserControl
    {
        public WineControl(Wine model)
        {
            InitializeComponent();

            this.NameLabel1.Text = model.Name;
            this.varietyLabel1.Text = model.Variety;
            this.wineryLabel1.Text = model.Winery;
            this.PriceLabel1.Text = model.Price.ToString();
            this.countryLabel1.Text = model.CountryName;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WinformsHelper.OpenGoogleSearch($"{this.NameLabel1.Text} {this.wineryLabel1.Text}");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i< Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].GetType() == typeof(MainForm))
                {
                    ((MainForm)Application.OpenForms[i]).graphs2ToolStripMenuItem.PerformClick();
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.SelectTab(1);
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.comboBox2.Text = this.NameLabel1.Text;
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.recommendButton2.PerformClick();
                }
            }
        }
    }
}
