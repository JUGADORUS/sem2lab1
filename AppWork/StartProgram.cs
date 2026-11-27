using BusinessLogic;
using Ninject;
using Presenter;
using sem2lab1;
using WindowsForms;
using static System.Windows.Forms.AxHost;
namespace AppWork
{
    internal class StartProgram
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Выберите интерфейс:");
            Console.WriteLine("1. Windows Forms");
            Console.WriteLine("2. Консоль");
            string choice = Console.ReadLine();

            IKernel kernel = new StandardKernel(new SimpleConfigModule());
            IDrugLaboratory drugLaboratory = kernel.Get<IDrugLaboratory>();

            if (choice == "1")
            {
                Starter.Initialize();

                StartForm startForm = new StartForm();

                if (startForm.ShowDialog() == DialogResult.OK)
                {
                    MainForm mainForm = new MainForm();
                    DrugPresenter presenter = new DrugPresenter(mainForm, drugLaboratory);

                    Starter.StartForm(mainForm);
                }
            }
            else if (choice == "2")
            {
                ConsoleView consoleView = new ConsoleView();
                DrugPresenter presenter = new DrugPresenter(consoleView, drugLaboratory);
                consoleView.Run();
            }
            else
            {
                Console.WriteLine("Ввод не распознан.");
            }

        }
    }
}
