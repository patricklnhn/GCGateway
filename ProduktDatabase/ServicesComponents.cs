using System.ComponentModel.DataAnnotations;

namespace ProduktDatabase
{
    public class ServicesComponents
    {
        public int Id { get; set; }
        public Services Service{ get; set; }
        public Component Component { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
