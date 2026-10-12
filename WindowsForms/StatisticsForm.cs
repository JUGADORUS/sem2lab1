using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class StatisticsForm : Form
    {
        private DrugLaboratory _drugLab;
        public StatisticsForm(DrugLaboratory lab)
        {
            InitializeComponent();
            _drugLab = lab;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats() 
        {
            DGV_Stats.Rows.Clear();

            Dictionary<string,Dictionary<string,int>> stats = _drugLab.GetDistrictStatistics();

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
