using DBPMessanger.Forms;
using DBPMessanger.infos;
using DBPMessanger.Managers;
using DBPMessanger.Config;
using Microsoft.EntityFrameworkCore;

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
            // 원격 서버 연결 실패 시에도 애플리케이션은 계속 실행
            try
            {
                using var db = new AppDBContext();
                db.Database.EnsureCreated(); // DB가 없으면 생성
            }
            catch (Exception ex)
            {
                // 연결 실패 시 조용히 무시 (로그인 시 다시 시도)
                System.Diagnostics.Debug.WriteLine($"DB 초기화 경고: {ex.Message}");
                // 사용자에게 메시지 표시하지 않고 계속 진행
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