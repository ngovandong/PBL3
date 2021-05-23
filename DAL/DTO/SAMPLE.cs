

namespace DAL.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SAMPLE")]
    public class SAMPLE
    {
        [Key]
        public int SAMPLEID { get; set; }
        
        [StringLength(50)]
        public string NAME { get; set; }

        public string PRESCRIPTION { get; set; }

        public virtual ICollection<SAMPLE_DETAIL> SAMPLE_DETAILs { get; set; }
    }
}
