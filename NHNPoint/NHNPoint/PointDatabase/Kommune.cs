using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Kommune
    {
        public int Id { get; set; }
        [StringLength(4)]
        public string Kommunenummer { get; set; } = default!;
        [StringLength(25)]
        public string Kommunenavn { get; set; } = default!;
        public Fylke Fylke { get; set; }
        public bool Active { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
