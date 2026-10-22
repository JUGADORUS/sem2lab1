using System;
using System.Windows.Forms;
using BusinesssLogic;
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

            DrugLaboratory drugLaboratory = kernel.Get<DrugLaboratory>();
            DrugStatisticsService statisticsService = kernel.Get<DrugStatisticsService>();


            StartForm startForm = new StartForm();

            if(startForm.ShowDialog() == DialogResult.OK) 
            {
                Application.Run(new MainForm(drugLaboratory, statisticsService));
            }
        }
    }
}
