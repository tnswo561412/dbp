using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBPMessanger.infos;

// 현재 로그인 세션 정보를 보관하는 클래스
namespace DBPMessanger.Config
{
    public static class SessionContext
    {
        public static UserInfo? CurrentUser { get; set; } // 현재 로그인한 사용자 정보
        public static long? CurrentLoginLogId { get; set; } // 현재 로그인 세션의 로그 ID

        public static void Clear() // 세션 정보 초기화
        {
            CurrentUser = null;
            CurrentLoginLogId = null;
        }
    }
}
