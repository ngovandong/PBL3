namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MEDICINE")]
    public partial class MEDICINE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICINE()
        {
            INVOICE_DETAIL = new HashSet<INVOICE_DETAIL>();
            STOCK_DETAIL = new HashSet<STOCK_DETAIL>();
        }
        [Key]
        public int ID { get; set; }

        [StringLength(10)]
        public string BARCODE { get; set; }

        [StringLength(350)]
        public string MEDICINE_NAME { get; set; }

        [StringLength(20)]
        public string MEDICINE_CODE { get; set; }

        [StringLength(100)]
        public string LOCATION { get; set; }

        [StringLength(15)]
        public string ID_SUB { get; set; }

        [StringLength(350)]
        public string INGREDIENT { get; set; }

        [StringLength(350)]
        public string CONTENT { get; set; }

        [StringLength(100)]
        public string BRAND { get; set; }

        

        public int? QUANTITY { get; set; }

        public int? ORIGINAL_PRICE { get; set; }

        public int? SALE_PRICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICE_DETAIL> INVOICE_DETAIL { get; set; }

        public int? TYPEID { get; set; }
        public virtual MEDICINE_TYPE MEDICINE_TYPE { get; set; }

        [Required]
        public int UNIT_ID { get; set; }
        public virtual UNIT UNIT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCK_DETAIL> STOCK_DETAIL { get; set; }
    }
}
