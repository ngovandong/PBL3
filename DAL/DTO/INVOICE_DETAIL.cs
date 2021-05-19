namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INVOICE_DETAIL
    {
        [StringLength(10)]
        public string ID { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_INVOICE { get; set; }

        [Required]
        [StringLength(10)]
        public string ID_MEDICINE { get; set; }

        public int? SALE_PRICE { get; set; }

        public int? QUANTITY { get; set; }

        public virtual INVOICE INVOICE { get; set; }

        public virtual MEDICINE MEDICINE { get; set; }
    }
}
