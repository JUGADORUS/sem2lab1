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

            const bool isEntityFramework = false;
            DrugLaboratory drugLab;

            if (isEntityFramework)
            {
                var dbContext = new DataAccessLayer.DBContext();
                var repository = new DataAccessLayer.EntityRepository<DrugBuyer>(dbContext);
                drugLab = new DrugLaboratory(repository);
            }
            else
            {
                var repository = new DataAccessLayer.DapperRepository<DrugBuyer>();
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
