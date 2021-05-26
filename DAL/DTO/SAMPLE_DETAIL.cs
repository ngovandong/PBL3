
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

        public int QTY { get; set; }

        [ForeignKey("MEDICINE")]
        public int MEDICINE_ID { get; set; }
        public virtual MEDICINE MEDICINE { get; set; }

        [ForeignKey("SAMPLE")]
        public int SAMPLE_ID { get; set; }
        public virtual SAMPLE SAMPLE { get; set; }
    }
}
