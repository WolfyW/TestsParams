using System.ComponentModel.DataAnnotations;

namespace TestsParams.Model
{
    public class Parameters
    {
        [Key]
        public int ParametrId { get; set; }

        public int TestId { get; set; }

        [Required]
        [StringLength(200)]
        public string ParameterName { get; set; }

        public decimal RequiredValue { get; set; }

        public decimal MeasuredValue { get; set; }

        public virtual Tests Tests { get; set; }
    }
}
