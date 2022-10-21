using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class HealthRegion
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        [StringLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
        [StringLength(25)] 
        public string User { get; set; } = default!;

        public DateTime TS { get; set; }
    }
}
