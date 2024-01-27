using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Models
{
    public class Users
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string strName { get; set; }
        [Required]
        [DisplayName("Username")]
        public string strUsername { get; set; }
        [Required]
        [DisplayName("Level")]
        public string strRole { get; set; }
        [Required]
        [DisplayName("Password")]
        public string strPassword { get; set; }
        public bool isDeleted { get; set; }
        public string CenterId { get; set; }

    }
}
