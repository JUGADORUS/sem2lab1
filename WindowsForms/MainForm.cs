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
        private DrugLaboratory _DrugLab;
        public MainForm( DrugLaboratory lab)
        {
            InitializeComponent();
            _DrugLab = lab;
        }

        private void MainForm_Load1(object sender, EventArgs e)
        {
            LoadBuyers();
        }

        private void LoadBuyers()
        {
            DGV_Buyers.DataSource = null;
            DGV_Buyers.DataSource = _DrugLab.GetAllBuyers();
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

            _DrugLab.RemoveBuyer(drugBuyer);
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

            _DrugLab.AddNewBuyer(name, district, favouriteDrug);
            MessageBox.Show("Новый покупатель успешно добавлен!");

            LoadBuyers();

            textBoxName.Clear();
            textBoxDistrict.Clear();
            textBoxDrug.Clear();

        }
    }
}
