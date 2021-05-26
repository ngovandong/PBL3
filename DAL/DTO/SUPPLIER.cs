

namespace DAL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUPPLIER")]
    public partial class SUPPLIER
    {
        [Key]
        public int ID { get; set; }
        
        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string PHONE_NUMBER { get; set; }

        [StringLength(50)]
        public string ADDRESS { get; set; }

        [StringLength(20)]
        public string EMAIL { get; set; }

        public virtual ICollection<STOCK> STOCKs { get; set; }
    }
}
