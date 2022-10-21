using System.ComponentModel.DataAnnotations;

namespace ProduktDatabase
{
    public class Services
    {
        public int Id { get; set; }
        public BusinesService BusinesService { get; set; }
        public int ServiceNumber { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = default!;
        [StringLength(15)]
        public string VersionNumber { get; set; } = default!;
        public bool Active { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
