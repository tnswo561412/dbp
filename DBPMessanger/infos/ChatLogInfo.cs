using DBPMessanger.infos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.Item
{
    [Table("ChatLog")]
    
    public class ChatLogInfo
    {

        [Key] public long Id { get; set; }



        public required long SenderUserId { get; set; }
        public required long TargetUserId { get; set; }

        // 내비게이션 프로퍼티
        [ForeignKey(nameof(SenderUserId))]
        public UserInfo Sender { get; set; }

        [ForeignKey(nameof(TargetUserId))]
        public UserInfo Target { get; set; }


        public required string Message { get; set; }
        public required DateTime MessageTime { get; set; }

        public ChatLogInfo() { }
    }
}
