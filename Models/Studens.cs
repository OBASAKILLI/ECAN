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
    public class Studens
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string strName { get; set; }
        [Required]
        [DisplayName("A/No")]
        public string strADNo { get; set; }
        [Required]
        [DisplayName("Center")]
        public string strCenterId { get; set; }
        [Required]
        [DisplayName("School")]
        public string strSchoolId { get; set; }
        [Required]
        [DisplayName("Sponser")]
        public string strSponserId { get; set; }
        [Required]
        [DisplayName("Guardian Name")]
        public string strGuarduianName { get; set; }
        [Required]
        [DisplayName("Guardian Phone")]
        public string strguardianPhone { get; set; }
        [Required]
        [DisplayName("Grade/Class")]
        public string strCgrade_Class { get; set; }          //...............
        [Required]
        [DisplayName("Admission Date")]
        public DateTime strADMDate { get; set; }
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime strDateOfBirth { get; set; }
        [Required]
        [DisplayName("Last Date of Fee Payent")]
        public DateTime strFeePaid { get; set; }         //................
        public bool isDeleted { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        [DisplayName("File")]
        [Required(ErrorMessage = "File cannot be empty")]
        public IFormFile ImageFile { get; set; }
    }
}
