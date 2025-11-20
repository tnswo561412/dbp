using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("LoginLog")]
    public class LoginLog
    {
        [Key] public long Id { get; set; }

        public long? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserInfo? User { get; set; }

        public DateTime? LoginTime { get; set; }

        public DateTime? LogoutTime { get; set; }

        

    }
}
