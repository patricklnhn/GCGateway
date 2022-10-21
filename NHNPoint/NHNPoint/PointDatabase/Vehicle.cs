using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Vehicle
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public VehicleType VehicleType { get; set; }
        [StringLength(25)]
        public string Name { get; set; }

        public string Registration { get; set; } = default!;
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
