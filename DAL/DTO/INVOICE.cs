namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVOICE")]
    public partial class INVOICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICE()
        {
            INVOICE_DETAIL = new HashSet<INVOICE_DETAIL>();
        }

        [Key]
        public int ID_INVOICE { get; set; }

        public DateTime DATE { get; set; }

        public int? TOTAL { get; set; }

        public double? DISCOUNT { get; set; }

        public string PRESCRIPTION { get; set; }

        public int? ID_CUSTOMER { get; set; }
        public virtual CUSTOMER CUSTOMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE_DETAIL> INVOICE_DETAIL { get; set; }

        public int? User_ID { get; set; }
        public virtual USER USER { get; set; }
    }
}
