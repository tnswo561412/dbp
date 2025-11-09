using DBPMessanger.infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.Managers
{
    public class OwnerUserManager
    {
        public UserInfo userInfo { get; private set; }


        public static OwnerUserManager Instance = new OwnerUserManager();
        private OwnerUserManager() { }

        public void initOwerUser(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }
    }
}
