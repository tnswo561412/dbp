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

            // DB 자동 생성 및 마이그레이션 (처음 실행 시 테이블 생성)
            try
            {
                using var db = new AppDBContext();
                db.Database.EnsureCreated(); // DB가 없으면 생성
            }
            catch (Exception ex)
            {
                MessageBox.Show($"DB 초기화 오류: {ex.Message}\n\nAppDBContext.cs에서 DB 연결 문자열을 확인하세요.",
                    "DB 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // �� ���� ���� �� ������ ���̽� ��� ������ġ
            Application.ApplicationExit += (_, __) =>
            {
                // Ȥ�� ���� �ִ� ������ ���� ó��
                LogoutHelper.PerformLogout();
            };

            NotifcationManager.Initialize();

            while (true)
            {
                using var login = new LoginForm();
                if (login.ShowDialog() != DialogResult.OK) break;

                Application.Run(new MainForm());
                // ���� �� ���� �� ���� ����(�ߺ� ����)
            }

            // Manager
            //NotifcationManager.Initialize();


            //Application.Run(new LoginForm());
        }
    }
}