using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBPMessanger.infos;

// 로그아웃 시간 기록 및 세션 초기화 클래스
namespace DBPMessanger.Config
{
    public static class LogoutHelper
    {
        public static void PerformLogout()
        {
            if (SessionContext.CurrentLoginLogId == null)  // 로그인 기록이 없으면 초기화
            {
                SessionContext.Clear();
                return;
            }

            try
            {
                using var db = new AppDBContext(); // DB 컨텍스트 생성

                // 현재 로그인 기록 조회
                var log = db.LoginLogs 
                    .FirstOrDefault(l => l.Id == SessionContext.CurrentLoginLogId.Value);

                // 로그아웃 시간 기록
                if (log != null && log.LogoutTime == null)
                {
                    log.LogoutTime = DateTime.Now;
                    db.SaveChanges(); // 변경 사항 저장
                }
            }
            catch
            {
                // 필요 시 로깅
            }
            finally
            {
                SessionContext.Clear();
            }
        }
    }
}
