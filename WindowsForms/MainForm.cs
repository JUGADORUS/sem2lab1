using System;
using Model;
using System.Windows.Forms;
using BusinesssLogic;


namespace WindowsForms
{
    public partial class MainForm : Form
    {
        private DrugLaboratory _drugLaboratory;

        public MainForm(DrugLaboratory lab)
        {
            InitializeComponent();
            _drugLaboratory = lab;

            DGV_Buyers.ReadOnly = true;
            DGV_Buyers.AllowUserToAddRows = false;
            DGV_Buyers.AllowUserToDeleteRows = false;
            DGV_Buyers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void MainForm_Load1(object sender, EventArgs e)
        {
            LoadBuyers();
            LoadDrugs();
        }

        private void LoadDrugs() 
        {
            listBoxDrugs.Items.Clear();

            foreach(string drug in _drugLaboratory.GetUniqueDrugs()) 
            {
                listBoxDrugs.Items.Add(drug);
            }
        }

        private void LoadBuyers()
        {
            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = _drugLaboratory.GetAllBuyers();
            listBoxDrugs.ClearSelected();
        }

        private void button_Delete_Click_1(object sender, EventArgs e)
        {
            if (DGV_Buyers.CurrentRow == null)
            {
                MessageBox.Show("Выберете пользователя для удаления, нажав на него в списке.");
                return;
            }

            DrugBuyer drugBuyer = DGV_Buyers.CurrentRow.DataBoundItem as DrugBuyer;

            if (drugBuyer == null)
            {
                MessageBox.Show("Не удалось определить покупателя. Попробуйте еще раз.");
                return;
            }

            var result = MessageBox.Show($"Удалить {drugBuyer.Name}?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            _drugLaboratory.RemoveBuyer(drugBuyer.Id);
            LoadBuyers();
            LoadDrugs();
        }

        private void button_Create_Click_1(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string district = textBoxDistrict.Text;
            string favouriteDrug = textBoxDrug.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(district) || string.IsNullOrWhiteSpace(favouriteDrug))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            _drugLaboratory.AddNewBuyer(name, district, favouriteDrug);
            MessageBox.Show("Новый покупатель успешно добавлен!");

            LoadBuyers();
            LoadDrugs();

            textBoxName.Clear();
            textBoxDistrict.Clear();
            textBoxDrug.Clear();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (DGV_Buyers.CurrentRow == null)
            {
                MessageBox.Show("Выберете пользователя для изменения данных, нажав на него в списке.");
                return;
            }

            DrugBuyer drugBuyer = DGV_Buyers.CurrentRow.DataBoundItem as DrugBuyer;

            if (drugBuyer == null)
            {
                MessageBox.Show("Не удалось определить покупателя. Попробуйте еще раз.");
                return;
            }

            int id = drugBuyer.Id;
            string name = textBoxName.Text;
            string district = textBoxDistrict.Text;
            string favouriteDrug = textBoxDrug.Text;

            if (string.IsNullOrWhiteSpace(name)) name = drugBuyer.Name;
            if (string.IsNullOrWhiteSpace(district)) district = drugBuyer.District;
            if (string.IsNullOrWhiteSpace(favouriteDrug)) favouriteDrug = drugBuyer.FavouriteDrug;

            if (drugBuyer.Name == name && drugBuyer.District == district && drugBuyer.FavouriteDrug == favouriteDrug)
            {
                MessageBox.Show("Введите новые данные для изменения.");

                textBoxName.Clear();
                textBoxDistrict.Clear();
                textBoxDrug.Clear();
                LoadBuyers();
                LoadDrugs();

                return;
            }

            var result = MessageBox.Show($"Изменить данные о {drugBuyer.Name}?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            if (drugBuyer.Name != name)
                _drugLaboratory.ChangeName(name, id);
            if (drugBuyer.District != district)
                _drugLaboratory.ChangeDistrict(district, id);
            if (drugBuyer.FavouriteDrug != favouriteDrug)
                _drugLaboratory.ChangeFavouriteDrug(favouriteDrug, id);

            MessageBox.Show("Данные успешно изменены.");

            textBoxName.Clear();
            textBoxDistrict.Clear();
            textBoxDrug.Clear();

            LoadBuyers();
            LoadDrugs();
        }

        private void listBoxDrugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDrugs.SelectedItem == null)
                 return; 

            string drug = listBoxDrugs.SelectedItem.ToString();

            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = _drugLaboratory.GetBuyersByDrug(drug);
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            listBoxDrugs.ClearSelected();
            LoadBuyers();
            LoadDrugs() ;
        }

        private void bttnReportDistricts_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(_drugLaboratory);
            statisticsForm.ShowDialog();
        }

        private void DGV_Buyers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
