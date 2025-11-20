using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("Favorites")]
    public class FavoritesInfo
    {
        [Key] public long Id { get; set; }

        public long? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserInfo? User { get; set; }

        public long? TargetUserId { get; set; }

        [ForeignKey(nameof(TargetUserId))]
        public UserInfo? TargetUser { get; set; }

        // Type: "EMPLOYEE" (직원 즐겨찾기) 또는 "CHAT" (채팅 즐겨찾기)
        public string Type { get; set; } = "EMPLOYEE";

        // DisplayOrder: 즐겨찾기 표시 순서 (낮을수록 위에 표시)
        public int DisplayOrder { get; set; } = 0;
    }
}
