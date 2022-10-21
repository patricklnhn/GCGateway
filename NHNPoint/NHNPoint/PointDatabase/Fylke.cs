using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Fylke
    {
        public int Id { get; set; }
        public int FylkesNummer { get; set; }
        public string FylkesNavn { get; set; } = default!;
        public HealthRegion HelseRegion { get; set; }
        public bool Active { get; set; }
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
