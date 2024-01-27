using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Models
{
    public class Centers
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("Center Name")]

        public string CenterName { get; set; }
        [DisplayName("Center Code")]
        [Required]
        public string CenterCode { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    }
}
