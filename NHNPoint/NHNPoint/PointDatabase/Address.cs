using System.ComponentModel.DataAnnotations;

namespace PointDatabase
{
    /// <summary>
    /// Address based on return from Matrikkelen, Kartverket
    /// </summary>
    public class Address
    {
        public int Id { get; set; }
        public string Adressenavn { get; set; } = default!;
        public string? Adressetilleggsnavn { get; set; } = default!;
        public Poststed Poststed { get; set; }
        public int Nummer { get; set; }
        public int GNR { get; set; }
        public int BNR { get; set; }
        public int? Undernummer { get; set; }
        public int? Bruksenhetsnummer { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}