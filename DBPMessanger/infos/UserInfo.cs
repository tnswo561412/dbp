using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("User")]
    public class UserInfo
    {
        [Key] public long Id { get; set; }

        public required string Name { get; set; }
        public required string LoginId { get; set; }
        public required string Password { get; set; }

        public byte[]? ProfileImage { get; set; }

        public int? Zipcode { get; set; }
        public string? Adress { get; set; }
        public string? Nickname { get; set; }
        public DateTime? Birthday { get; set; }

        public required long DepartmentId { get; set; }

        // 내비게이션 프로퍼티
        [ForeignKey(nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        public UserInfo() { }
    }
}
