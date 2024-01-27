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
    public class Events
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("Student")]
        public string strStudentId { get; set; }
        [Required]
        [DisplayName("Event")]
        public string strEvent { get; set; }
        [Required]
        [DisplayName("Date")]
        public DateTime strDate { get; set; }
        public bool Isdelered { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        [DisplayName("File")]
      //  [Required(ErrorMessage = "File cannot be empty")]
        public IFormFile ImageFile { get; set; }

    }
}
