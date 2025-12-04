namespace Pr5_Salov.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Group_ { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
    }
}
