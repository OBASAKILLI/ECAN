using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECAN_CRF.Models
{
    public class Sponsers
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("Sponser Name")]
        public string stName { get; set; }
     
        [DisplayName("Sponser PhotoUrl")]
        public string stImageURl { get; set; }
        [Required]
        [DisplayName("Country")]
        public string stCountry { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        [DisplayName("File")]
        [Required(ErrorMessage = "File cannot be empty")]
        public IFormFile ImageFile { get; set; }
    }
}
