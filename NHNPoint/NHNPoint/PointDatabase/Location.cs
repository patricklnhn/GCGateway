using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Location
    {
        public int Id { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(15)]
        public string OrgNumber { get; set; }
        public bool Active { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
