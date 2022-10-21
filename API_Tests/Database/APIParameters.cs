using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Database
{
    public class APIParameters
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string ParameterName { get; set; } = default!;
        [StringLength(100)]
        [Required]
        public string ParameterValue { get; set; } = default!;
        [Required]
        [ForeignKey("Id")]
        public ExternalAPIs ExternalAPI { get; set; }

    }
}
