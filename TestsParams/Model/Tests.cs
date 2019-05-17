using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace TestsParams.Model
{
    public class Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tests()
        {
            Parameters = new HashSet<Parameters>();
        }

        [Key]
        public int TestId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime TestDate { get; set; }

        [Required]
        [StringLength(50)]
        public string BlockName { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Parameters> Parameters { get; set; }
    }
}
