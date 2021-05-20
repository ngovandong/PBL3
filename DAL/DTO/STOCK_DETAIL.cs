namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STOCK_DETAIL
    {
        [Key]
        public int ID { get; set; }



        public int? ORGIGINAL_PRICE { get; set; }

        public int? QUANTITY { get; set; }

        [StringLength(20)]
        public string NAME { get; set; }


        [Required]
        public int ID_MEDICINE { get; set; }
        public virtual MEDICINE MEDICINE { get; set; }

        [Required]
        public int ID_STOCK { get; set; }
        public virtual STOCK STOCK { get; set; }
    }
}
