using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinesssLogic;

namespace WindowsForms
{
    public partial class StatisticsForm : Form
    {
        private DrugStatisticsService _drugStatisticsService;
        public StatisticsForm(DrugStatisticsService lab)
        {
            InitializeComponent();
            _drugStatisticsService = lab;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats() 
        {
            DGV_Stats.Rows.Clear();

            Dictionary<string,Dictionary<string,int>> stats = _drugStatisticsService.GetDistrictStatistics();

            foreach (var district in stats) 
            {
                foreach (var drug in district.Value) 
                {
                    DGV_Stats.Rows.Add(district.Key,drug.Key, drug.Value);
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
