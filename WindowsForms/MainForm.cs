using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsForms
{
    public partial class MainForm : Form, IView
    {
        event EventHandler<DrugBuyerEventArgs> AddBuyerRequested;
        event EventHandler<DrugBuyerEventArgs> RemoveBuyerRequested;
        event EventHandler<DrugBuyerEventArgs> UpdateBuyerRequested;
        event EventHandler AllBuyersRequested;
        event EventHandler<DrugBuyerEventArgs> BuyersByDrugRequested;
        event EventHandler StatisticsRequested;

        public MainForm()
        {
            InitializeComponent();

            DGV_Buyers.ReadOnly = true;
            DGV_Buyers.AllowUserToAddRows = false;
            DGV_Buyers.AllowUserToDeleteRows = false;
            DGV_Buyers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ShowBuyers(List<DrugBuyerDto> buyers) 
        {
            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = buyers;
            listBoxDrugs.ClearSelected();
        }

        private void ShowDrugs(List<string> drugs) 
        {
            listBoxDrugs.Items.Clear();
            foreach (string drug in drugs) 
            {
                listBoxDrugs.Items.Add(drug);
            }
            listBoxDrugs.ClearSelected();
        }

        private void ShowMessage(string message) 
        {
            MessageBox.Show(message);
        }

        private void MainForm_Load1(object sender, EventArgs e)
        {
            AllBuyersRequested?.Invoke(this, EventArgs.Empty);
        }

        private void button_Create_Click_1(object sender, EventArgs e)
        {
            var dto = new DrugBuyerDto
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

            var dtoToUpdate = new DrugBuyerDto 
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
            var dto = new DrugBuyerDto { FavouriteDrug = drug };

            //????
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            //????
        }

        private void bttnReportDistricts_Click(object sender, EventArgs e)
        {
            //????
        }

        private void DGV_Buyers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
