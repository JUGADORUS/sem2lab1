using System;
using System.Windows.Forms;
using BusinessLogic;
using Ninject;

namespace WindowsForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new SimpleConfigModule());

            IDrugLaboratory drugLaboratory = kernel.Get<IDrugLaboratory>();
            DrugStatisticsService statisticsService = kernel.Get<DrugStatisticsService>();


            StartForm startForm = new StartForm();

            if(startForm.ShowDialog() == DialogResult.OK) 
            {
                Application.Run(new MainForm(drugLaboratory, statisticsService));
            }
        }
    }
}
