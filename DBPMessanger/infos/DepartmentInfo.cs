using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("Department")]
    public class DepartmentInfo
    {

        [Key] public long Id { get; set; }
        public string? Name { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public DepartmentInfo? Parent { get; set; }

        public List<DepartmentInfo>? Children { get; set; } = new List<DepartmentInfo>();

        public List<UserInfo>? Users { get; set; } = new List<UserInfo>();

        public DepartmentInfo() { }
    }
}
