using System.ComponentModel.DataAnnotations;

namespace Database
{
    public class TypeOfReturn
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; } = default!;
    }
}
