using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace DAL.DTO
{
    [Table("PHARMACY_PROFILE")]
    public class PHARMACY_PROFILE
    {
        [Key]
        public int PHARMACY_PROFILEID { get; set; }
        
        [StringLength(50)]
        public string PharmacyName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(20)]
        public string BusinessHours { get; set; }
    }
}
