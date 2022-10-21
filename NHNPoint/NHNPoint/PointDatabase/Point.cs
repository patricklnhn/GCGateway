using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Point
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Type { get; set; } = default!;
        public Room? Room { get; set; }
        public Building? Building { get; set; }
        public Vehicle? Vehicle { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
