using System.ComponentModel.DataAnnotations;

namespace PointDatabase
{
    public class Building
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public Location Location { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        [StringLength(50)]
        public string EPSG { get; set; } = default!;
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
