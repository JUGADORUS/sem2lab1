using System.Windows.Forms;

namespace WindowsForms
{
    public static class Starter
    {
        /// <summary>
        /// Инициализирует Windows Forms.
        /// </summary>
        public static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }

        /// <summary>
        /// Запускает указанную форму.
        /// </summary>
        /// <param name="form">Запускаемая форма</param>
        public static void StartForm(Form form)
        {
            Application.Run(form);
        }
    }
}