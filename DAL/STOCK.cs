namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STOCK")]
    public partial class STOCK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STOCK()
        {
            STOCK_DETAIL = new HashSet<STOCK_DETAIL>();
        }

        [StringLength(10)]
        public string ID { get; set; }

        public DateTime? DATE { get; set; }

        [StringLength(100)]
        public string SUPPLIERNAME { get; set; }

        [Column(TypeName = "text")]
        public string NOTE { get; set; }

        public int? PRICETOTAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_DETAIL> STOCK_DETAIL { get; set; }
    }
}
