using System.ComponentModel.DataAnnotations;

namespace ProduktDatabase
{
    public class ServicesCostAndIncome
    {
        public int Id { get; set; }
        public Services Service { get; set; }
        public DateTime FromDate { get; set; }
        public int OTR { get; set; }
        public int MRR { get; set; }
        public int OTC { get; set; }
        public int MRC { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
