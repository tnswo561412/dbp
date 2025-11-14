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

        public required long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserInfo User { get; set; }

        public required long TargetUserId { get; set; }

        [ForeignKey(nameof(TargetUserId))]
        public UserInfo TargetUser { get; set; }
    }
}
