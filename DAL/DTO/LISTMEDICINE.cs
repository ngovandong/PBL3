namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LISTMEDICINE")]
    public partial class LISTMEDICINE
    {
        [Key]
        public int id { get; set; }

        [StringLength(300)]
        public string medicine_name { get; set; }

        [StringLength(300)]
        public string medicine_code { get; set; }

        [StringLength(150)]
        public string no_subscribe { get; set; }

        [StringLength(300)]
        public string chemicals { get; set; }

        [StringLength(300)]
        public string content { get; set; }

        [StringLength(300)]
        public string branch { get; set; }

        public override string ToString()
        {
            return this.medicine_name;
        }
    }
}
