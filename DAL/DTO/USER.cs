namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            INVOICEs = new HashSet<INVOICE>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(15)]
        public string PHONE { get; set; }

        [StringLength(100)]
        public string ADDRESS { get; set; }

        [Column(TypeName = "image")]
        public byte?[] IMAGE { get; set; }

        [StringLength(10)]
        public string ID_CMND { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [Required]
        [StringLength(20)]
        public string PASSWORD { get; set; }

        public bool ROLE { get; set; } // true is addmin false is staff
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
