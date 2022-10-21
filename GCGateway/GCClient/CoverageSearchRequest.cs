using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCClient
{
    /// <summary>
    /// Reqeust object for coverage search
    /// </summary>
    public class CoverageSearchRequest
    {
        public string articleGroupName { get; set; } = default!;
        public int articleGroupID { get; set; }
        public int fromAddressGabId { get; set; }
        public string fromAddressStreetName { get; set; } = default!;
        public string fromAddressHouseNumber { get; set; } = default!;
        public string fromAddressHouseLetter { get; set; } = default!;
        public string fromAddressPostCode { get; set; } = default!;
        public string fromAddressCity { get; set; } = default!;
        public int toAddressGabId { get; set; }
        public string toAddressStreetName { get; set; } = default!;
        public string toAddressHouseNumber { get; set; } = default!;
        public string toAddressHouseLetter { get; set; } = default!;
        public string toAddressPostCode { get; set; } = default!;
        public string toAddressCity { get; set; } = default!;
        public string multiAccessPointName { get; set; } = default!;
    }
}
