namespace DAL
{
    using DAL.DTO;
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
        [Key]
        public int ID { get; set; }

        public DateTime? DATE { get; set; }
        
        [StringLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string NOTE { get; set; }

        public int? PRICETOTAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_DETAIL> STOCK_DETAIL { get; set; }

        [ForeignKey("SUPPLIER")]
        public int? supplierId { get; set; }
        public virtual SUPPLIER SUPPLIER { get; set; }
    }
}
