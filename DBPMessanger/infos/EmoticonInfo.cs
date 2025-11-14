using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBPMessanger.infos
{
    [Table("Emoticon")]
    public class EmoticonInfo
    {
        [Key] public long Id { get; set; }

        public byte[]? Image { get; set; }
    }
}
