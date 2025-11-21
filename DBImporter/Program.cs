using MySql.Data.MySqlClient;
using System;
using System.IO;

class FixUserTable
{
    static void Main(string[] args)
    {
        string connectionString = "server=223.130.151.111;port=3306;database=s5701454;user=s5701454;password=s5701454;AllowUserVariables=True;";
        string sqlFilePath = @"C:\Users\tnswo\Documents\dumps\Dump20251121\dbp_messenger_user.sql";

        try
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("데이터베이스 연결 성공!");

                // 기존 User 테이블 삭제 (대문자)
                Console.WriteLine("기존 User 테이블 삭제 중...");
                using (var cmd = new MySqlCommand("DROP TABLE IF EXISTS `User`", connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("User 테이블 삭제 완료");

                // user 테이블 SQL 파일 실행
                Console.WriteLine("user 테이블 생성 중...");
                string sql = File.ReadAllText(sqlFilePath);
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("user 테이블 생성 완료!");

                // 테이블 목록 확인
                Console.WriteLine("\n현재 user 관련 테이블:");
                using (var cmd = new MySqlCommand("SHOW TABLES LIKE '%user%'", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("  - " + reader.GetString(0));
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"오류 발생: {ex.Message}");
            Console.WriteLine($"상세: {ex.StackTrace}");
        }
    }
}
