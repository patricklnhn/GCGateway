using System.ComponentModel.DataAnnotations;

namespace OffersAndServicesDatabase
{
    public class Request
    {
        public int Id { get; set; }
        public int BusinesServiceID { get; set; }
        public int LocationID { get; set; }
        public int  ContactId { get; set; }
        [StringLength(25)] public string ContactName { get; set; } = default!;
        [StringLength(25)] public string RegisteredBy { get; set; } = default!;
        public DateTime RegisteredDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string  Description { get; set; }
    }
}
