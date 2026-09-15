using System;
using BusinessLogic;
using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsForms
{
    public partial class MainForm : Form
    {
        private DrugLaboratory _drugLab;

        public MainForm( DrugLaboratory lab)
        {
            InitializeComponent();
            _drugLab = lab;
        }

        private void MainForm_Load1(object sender, EventArgs e)
        {
            LoadBuyers();
        }

        private void LoadBuyers()
        {
            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = _drugLab.GetAllBuyers();
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

            _drugLab.RemoveBuyer(drugBuyer);
            LoadBuyers();
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

            _drugLab.AddNewBuyer(name, district, favouriteDrug);
            MessageBox.Show("Новый покупатель успешно добавлен!");

            LoadBuyers();

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

            string name = textBoxName.Text;
            string district = textBoxDistrict.Text;
            string favouriteDrug = textBoxDrug.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(district) || string.IsNullOrWhiteSpace(favouriteDrug))
            {
                MessageBox.Show("Заполните все поля перед изменением!");
                return;
            }

            if (drugBuyer.Name == name && drugBuyer.District == district && drugBuyer.FavouriteDrug == favouriteDrug)
            {
                MessageBox.Show("Введите новые данные для изменения.");

                textBoxName.Clear();
                textBoxDistrict.Clear();
                textBoxDrug.Clear();
                LoadBuyers();

                return;

            }

            var result = MessageBox.Show($"Изменить данные о {drugBuyer.Name}?", "Подтверждение", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            drugBuyer.Name = name;
            drugBuyer.District = district;
            drugBuyer.FavouriteDrug = favouriteDrug;

            MessageBox.Show("Данные успешно изменены.");

            textBoxName.Clear();
            textBoxDistrict.Clear();
            textBoxDrug.Clear();

            LoadBuyers();
        }
    }
}
