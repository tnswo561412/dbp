using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("AuthorityUser")]
    public class AuthorityUserInfo
    {
        [Key] public long Id { get; set; }

        public long? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserInfo? User { get; set; }

        public long? TargetUserId { get; set; }

        [ForeignKey(nameof(TargetUserId))]
        public UserInfo? TargetUser { get; set; }

        public bool CanView { get; set; }
    }
}
