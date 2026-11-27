using System.Windows.Forms;

namespace WindowsForms
{
    public static class Starter
    {
        // <summary>  Запускает работу приложения и запускает указанную форму </summary>
        /// <param name="message"> Текст сообщения для отображения </param>
        public static void StartForm(Form form)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
    }
}
