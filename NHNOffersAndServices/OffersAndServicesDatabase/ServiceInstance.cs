using System.ComponentModel.DataAnnotations;

namespace OffersAndServicesDatabase
{
    public class ServiceInstance
    {
        public int Id { get; set; }
        public int ServiceNumber { get; set; }
        public Request Request { get; set; }
        [StringLength(15)] 
        public string OrgNumber { get; set; } = default!;
        public int ServiceLocation { get; set; }
        public int RedundantServiceLocation { get; set; }
        public int ServiceContactId { get; set; }
        [StringLength(25)] 
        public string ServiceContactName { get; set; } = default!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public TechnicalStatus TechnicalStatus { get; set; }
        public MercantileStatus MercantileStatus { get; set; }
        [StringLength(15)]
        public string VersionNumber { get; set; } = default!;
        public DateTime OfferValidToDate { get; set; }
        [StringLength(25)] 
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }

    }
}
