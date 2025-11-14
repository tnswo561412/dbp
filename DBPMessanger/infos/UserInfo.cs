using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    public enum ROLE
    {
        ADMIN,
        USER
    }

    [Table("User")]
    public class UserInfo
    {
        [Key] public long Id { get; set; }

        public required string Name { get; set; }
        public required string LoginId { get; set; }
        public required string Password { get; set; }

        public byte[]? Image { get; set; }

        public required int Zipcode { get; set; }
        public required string Address { get; set; }
        public string? Nickname { get; set; }
        public DateTime? Birthday { get; set; }

        public required long DepartmentId { get; set; }

        // 내비게이션 프로퍼티
        [ForeignKey(nameof(DepartmentId))]
        public DepartmentInfo Department { get; set; }

        public ROLE? Role { get; set; }

        public UserInfo() { }
    }
}
