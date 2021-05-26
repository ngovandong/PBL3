namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOCK_DETAIL
    {
        public int ORGIGINAL_PRICE { get; set; }

        public int QUANTITY { get; set; }

        [Required] 
        public DateTime dateExpire { get; set; }

        [ForeignKey("MEDICINE")]
        public int ID_MEDICINE { get; set; }
        public virtual MEDICINE MEDICINE { get; set; }

        [ForeignKey("STOCK")]
        public int ID_STOCK { get; set; }
        public virtual STOCK STOCK { get; set; }

        public override string ToString()
        {
            return STOCK.Name;
        }
    }
}
