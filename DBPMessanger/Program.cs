using DBPMessanger.Forms;
using DBPMessanger.infos;
using DBPMessanger.Managers;
using DBPMessanger.Config;

namespace DBPMessanger
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // 앱 강제 종료 등 비정상 케이스 대비 안전장치
            Application.ApplicationExit += (_, __) =>
            {
                // 혹시 남아 있는 미종료 세션 처리
                LogoutHelper.PerformLogout();
            };

            NotifcationManager.Initialize();

            while (true)
            {
                using var login = new LoginForm();
                if (login.ShowDialog() != DialogResult.OK) break;

                Application.Run(new MainForm());
                // 메인 폼 닫힐 때 세션 종료(중복 안전)
            }

            // Manager
            //NotifcationManager.Initialize();


            //Application.Run(new LoginForm());
        }
    }
}