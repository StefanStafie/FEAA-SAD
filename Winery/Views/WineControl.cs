using System;
using System.Windows.Forms;
using Winery.Helper;
using Winery.Models;

namespace Winery.Views
{
    public partial class WineControl : UserControl
    {
        public WineControl(Wine model)
        {
            InitializeComponent();

            NameLabel1.Text = model.Name;
            varietyLabel1.Text = model.Variety;
            wineryLabel1.Text = model.Winery;
            PriceLabel1.Text = model.Price.ToString();
            countryLabel1.Text = model.CountryName;
        }

        private void googleMenuItem_Click(object sender, EventArgs e)
        {
            WinformsHelper.OpenGoogleSearch($"{NameLabel1.Text} {wineryLabel1.Text}");
        }

        private void GetRecommendationMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].GetType() == typeof(MainForm))
                {
                    ((MainForm)Application.OpenForms[i]).graphs2ToolStripMenuItem.PerformClick();
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.SelectTab(1);
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.comboBox2.Text = NameLabel1.Text;
                    ((MainForm)Application.OpenForms[i]).graphsTabControl2.recommendButton2.PerformClick();
                }
            }
        }
    }
}
