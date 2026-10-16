using DataAccessLayer;
using Model;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            const bool isEntityFramework = true;
            DrugLaboratory drugLab;

            if (isEntityFramework)
            {
                EntityRepository<DrugBuyer> repository = new DataAccessLayer.EntityRepository<DrugBuyer>();
                drugLab = new DrugLaboratory(repository);
            }
            else
            {
                DapperRepository<DrugBuyer> repository = new DataAccessLayer.DapperRepository<DrugBuyer>();
                drugLab = new DrugLaboratory(repository);
            }

            
            StartForm startForm = new StartForm();

            if(startForm.ShowDialog() == DialogResult.OK) 
            {
                Application.Run(new MainForm(drugLab));
            }
        }
    }
}
