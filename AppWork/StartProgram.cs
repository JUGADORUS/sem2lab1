using BusinessLogic;
using Ninject;
using Presenter;
using System;
using System.Windows.Forms;
using WindowsForms;
using static System.Net.Mime.MediaTypeNames;
namespace AppWork
{
    public class StartProgram
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new SimpleConfigModule());
            IDrugLaboratory drugLaboratory = kernel.Get<IDrugLaboratory>();


            StartForm startForm = new StartForm();

            if (startForm.ShowDialog() == DialogResult.OK)
            {
                MainForm mainForm = new MainForm();
                DrugPresenter presenter = new DrugPresenter(mainForm, drugLaboratory);
                
                Application.Run(mainForm);
            }
        }
    }
}
