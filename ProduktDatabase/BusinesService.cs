using System.ComponentModel.DataAnnotations;

namespace ProduktDatabase
{
    public class BusinesService
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = default!;
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }

    }
}