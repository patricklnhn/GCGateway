using System.Security.AccessControl;

namespace OffersAndServicesDatabase
{
    public class OptionsChosen
    {
        public int Id { get; set; }
        public ServiceInstance ServiceInstance { get; set; }
        public Options Option { get; set; }
        public OptionValues OptionValue { set; get; }
        
    }
}
