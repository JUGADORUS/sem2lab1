using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class StatisticsForm : Form
    {
        private Dictionary<string, Dictionary<string, int>> _statistics;
        public StatisticsForm(Dictionary<string, Dictionary<string, int>> statistics)
        {
            InitializeComponent();
            _statistics = statistics;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            DGV_Stats.Rows.Clear();
            foreach (var district in _statistics)
            {
                foreach (var drug in district.Value)
                {
                    DGV_Stats.Rows.Add(district.Key, drug.Key, drug.Value);
                }
            }
        }

        private void DGV_Stats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
