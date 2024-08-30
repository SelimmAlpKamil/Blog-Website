using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutInfo
    {
        [Key]
        public int AboutInfoId { get; set; }
        [StringLength(1000)]
        public string Addres { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string EmailAddress { get; set; }
    }
}
