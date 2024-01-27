using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Models
{
    public class Schools
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("School Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Center Id")]
        public string CenterId { get; set; }
        public bool IsDeleted { get; set; }
     
    }

    public class SchoolsTwo
    {
       
        public string strId { get; set; }
     
        public string Name { get; set; }
        public string CeterIdOriginal { get; set; }
       
        public string CenterId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
