using System.ComponentModel.DataAnnotations;

namespace ProduktDatabase
{
    public class OptionsPerService
    {
        public int Id { get; set; }
        public Services Service { get; set; }
        public Options Option { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
