using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsForms
{
    public partial class MainForm : Form, IView
    {
        public event EventHandler<DrugBuyerEventArgs> AddBuyerRequested;
        public event EventHandler<DrugBuyerEventArgs> RemoveBuyerRequested;
        public event EventHandler<DrugBuyerEventArgs> UpdateBuyerRequested;
        public event EventHandler AllBuyersRequested;
        public event EventHandler<DrugBuyerEventArgs> BuyersByDrugRequested;
        public event EventHandler StatisticsRequested;

        public MainForm()
        {
            InitializeComponent();

            DGV_Buyers.ReadOnly = true;
            DGV_Buyers.AllowUserToAddRows = false;
            DGV_Buyers.AllowUserToDeleteRows = false;
            DGV_Buyers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ShowBuyers(List<DrugBuyerDto> buyers) 
        {
            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = buyers;
            listBoxDrugs.ClearSelected();
        }

        public void ShowDrugs(List<string> drugs) 
        {
            listBoxDrugs.Items.Clear();
            foreach (string drug in drugs) 
            {
                listBoxDrugs.Items.Add(drug);
            }
            listBoxDrugs.ClearSelected();
        }

        public void ShowStatistics(Dictionary<string, Dictionary<string, int>> statistics) 
        {
            StatisticsForm statisticForm = new StatisticsForm(statistics);
            statisticForm.ShowDialog();
        }

        public void ShowMessage(string message) 
        {
            MessageBox.Show(message);
        }

        private void MainForm_Load1(object sender, EventArgs e)
        {
            AllBuyersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void button_Create_Click_1(object sender, EventArgs e)
        {
            DrugBuyerDto dto = new DrugBuyerDto
            {
                Name = textBoxName.Text,
                District = textBoxDistrict.Text,
                FavouriteDrug = textBoxDrug.Text,
            };

            AddBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
        }

        private void button_Delete_Click_1(object sender, EventArgs e)
        {
            if (DGV_Buyers.CurrentRow == null) 
            {
                MessageBox.Show("Выберите пользователя перед удалением.");
                return;
            }
            var dto = DGV_Buyers.CurrentRow.DataBoundItem as DrugBuyerDto;
            if (dto == null) return;

            RemoveBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (DGV_Buyers.CurrentRow == null)
            {
                MessageBox.Show("Выберете пользователя для изменения данных, нажав на него в списке.");
                return;
            }

            var selectedDto = DGV_Buyers.CurrentRow.DataBoundItem as DrugBuyerDto;
            if (selectedDto == null) return;

            DrugBuyerDto dtoToUpdate = new DrugBuyerDto 
            {
                Id = selectedDto.Id,
                Name = textBoxName.Text,
                District = textBoxDistrict.Text,
                FavouriteDrug = textBoxDrug.Text
            };

            UpdateBuyerRequested?.Invoke(this, new DrugBuyerEventArgs(dtoToUpdate));

            textBoxName.Clear();
            textBoxDistrict.Clear();
            textBoxDrug.Clear();
        }

        private void listBoxDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDrugs.SelectedItem == null) return;

            string drug = listBoxDrugs.SelectedItem.ToString();
            DrugBuyerDto dto = new DrugBuyerDto { FavouriteDrug = drug };

            BuyersByDrugRequested?.Invoke(this, new DrugBuyerEventArgs(dto));
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            listBoxDrugs.ClearSelected();
            AllBuyersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void bttnReportDistricts_Click(object sender, EventArgs e)
        {
            StatisticsRequested?.Invoke(this, EventArgs.Empty);
        }

        private void DGV_Buyers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
