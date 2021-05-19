namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFF")]
    public partial class STAFF
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            INVOICEs = new HashSet<INVOICE>();
        }

        public string ID { get; set; }

        public string NAME { get; set; }

        public int? AGE { get; set; }

        [StringLength(15)]
        public string PHONE { get; set; }

        [StringLength(100)]
        public string ADDRESS { get; set; }

        [Column(TypeName = "image")]
        public byte[] IMAGE { get; set; }

        [StringLength(10)]
        public string ID_CMND { get; set; }

        [Required]
        [Column(TypeName = "nVARCHAR")]
        [StringLength(50)]
        public string USER_NAME { get; set; }

        [Required]
        [Column(TypeName = "nVARCHAR")]
        [StringLength(20)]
        public string PASSWORD { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
