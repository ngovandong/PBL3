namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INVOICE_DETAIL
    {

        public int SALE_PRICE { get; set; }
        public int ORIGINAL_PRICE { get; set; }

        public int QUANTITY { get; set; }

        [ForeignKey("INVOICE")]
        public int ID_INVOICE { get; set; }
        public virtual INVOICE INVOICE { get; set; }

        [ForeignKey("MEDICINE")]
        public int ID_MEDICINE { get; set; }
        public virtual MEDICINE MEDICINE { get; set; }
    }
}
