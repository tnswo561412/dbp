using DBPMessanger.infos;
using DBPMessanger.Item;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.Config
{
    public class AppDBContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<DepartmentInfo> Departments { get; set; }
        public DbSet<ChatLogInfo> ChatLogs { get; set; }

        // 서버 연결 설정하기
        private string connectionStr = "11";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SnakeCase네이밍으로 이용 (UserId -> user_id)
            optionsBuilder.UseMySql(connectionStr, new MySqlServerVersion(new Version(8, 0, 33)))
                .UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 삭제 옵션 Cascade / Restrict / SetNull / NoAction

            // ChatLog 관계 설정
            modelBuilder.Entity<ChatLogInfo>()
                .HasOne(c => c.Sender)              // 일대다 관계
                .WithMany()
                .HasForeignKey(c => c.SenderUserId) // 키 매핑 long타입
                .OnDelete(DeleteBehavior.Restrict); // 유저가 남아있으면 삭제 금지

            modelBuilder.Entity<ChatLogInfo>()
                .HasOne(c => c.Target)              // 일대다
                .WithMany()
                .HasForeignKey(c => c.TargetUserId) // 키 매핑
                .OnDelete(DeleteBehavior.Restrict);

            // Department Parent-Children 관계
            modelBuilder.Entity<DepartmentInfo>()
                .HasMany(d => d.Children)           // 다대일
                .WithOne(d => d.Parent)
                .HasForeignKey(d => d.ParentId)     // 키 매핑
                .OnDelete(DeleteBehavior.Restrict);

            // User 관계
            modelBuilder.Entity<UserInfo>()
                .HasOne(u => u.Department)          // 일대다      
                .WithMany(d => d.Users)          
                .HasForeignKey(u => u.DepartmentId) 
                .OnDelete(DeleteBehavior.SetNull);  
        }
    }
}
