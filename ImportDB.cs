using MySql.Data.MySqlClient;
using System;
using System.IO;

class ImportDB
{
    static void Main(string[] args)
    {
        string connectionString = "server=223.130.151.111;port=3306;database=s5701454;user=s5701454;password=s5701454;AllowUserVariables=True;";
        string dumpPath = @"C:\Users\tnswo\Documents\dumps\Dump20251121";

        // SQL 파일 목록 (순서대로 실행)
        string[] sqlFiles = new string[]
        {
            "dbp_messenger___efmigrationshistory.sql",
            "dbp_messenger_department.sql",
            "dbp_messenger_user.sql",
            "dbp_messenger_authoritychat.sql",
            "dbp_messenger_authoritydepartment.sql",
            "dbp_messenger_authorityuser.sql",
            "dbp_messenger_chatlog.sql",
            "dbp_messenger_favorites.sql",
            "dbp_messenger_loginlog.sql",
            "dbp_messenger_multiprofile.sql"
        };

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("데이터베이스 연결 성공!");

                foreach (var sqlFile in sqlFiles)
                {
                    string filePath = Path.Combine(dumpPath, sqlFile);

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"파일을 찾을 수 없습니다: {sqlFile}");
                        continue;
                    }

                    Console.WriteLine($"실행 중: {sqlFile}");

                    string sql = File.ReadAllText(filePath);

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine($"완료: {sqlFile}");
                }

                Console.WriteLine("\n모든 SQL 파일이 성공적으로 임포트되었습니다!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
            Console.WriteLine($"상세: {ex.StackTrace}");
        }

        Console.WriteLine("\n아무 키나 누르면 종료합니다...");
        Console.ReadKey();
    }
}
