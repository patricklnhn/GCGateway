using System.ComponentModel.DataAnnotations;

namespace OffersAndServicesDatabase
{
    public class Options
    {
        public int Id { get; set; }
        [StringLength(25)] 
        public string Name { get; set; } = default!;
        public int OTC { get; set; }
        public int MRC { get; set; }
        [StringLength(25)] public string User { get; set; } = default!;
        public DateTime  TS { get; set; }
    }
}