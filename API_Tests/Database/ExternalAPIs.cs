using System.ComponentModel.DataAnnotations;
namespace Database
{
    public class ExternalAPIs
    {
        public int Id { get; set; }
        [StringLength(25)]
        [Required]
        public string Name { get; set; } = default!;
        [StringLength(100)]
        public string Description { get; set; } = default!;
        [StringLength(50)]
        [Required]
        public  string Url { get; set; } = default!;
        [Required]
        public TypeOfReturn TypeOfReturn { get; set; }
        public bool NeedsAuthentication { get; set; } = false;
    }
}