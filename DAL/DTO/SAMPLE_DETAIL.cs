
namespace DAL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAMPLE_DETAIL")]
    public class SAMPLE_DETAIL
    {
        [Key]
        public int SAMPLE_DETAILID { get; set; }

        public int QTY { get; set; }

        [Required]
        [ForeignKey("MEDICINE")]
        public int MEDICINE_ID { get; set; }
        public virtual MEDICINE MEDICINE { get; set; }

        [Required]
        [ForeignKey("SAMPLE")]
        public int SAMPLE_ID { get; set; }
        public virtual SAMPLE SAMPLE { get; set; }
    }
}
