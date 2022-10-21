using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Poststed
    {
        public int Id { get; set; }
        public string PostNummer { get; set; } = default!;
        public string Navn { get; set; } = default!;
        public Kommune Kommune { get; set; }
        public bool Active { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }

    }
}
