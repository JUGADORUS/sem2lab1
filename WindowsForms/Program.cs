using System;
using System.Windows.Forms;
using Model;
using DataAccessLayer;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repository = new DataAccessLayer.DapperRepository<DrugBuyer>();
            DrugLaboratory drugLab = new DrugLaboratory(repository);
            StartForm startForm = new StartForm();

            if(startForm.ShowDialog() == DialogResult.OK) 
            {
                Application.Run(new MainForm(drugLab));
            }
        }
    }
}
