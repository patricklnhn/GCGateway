//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace JuntaClient
{
    public partial class PopProxy
    {
        public string name { get; set; } = default!;
        public proxyAddress pAddress { get; set; }
        public decimal geo_latitude { get; set; }
        public decimal geo_longtitude { get; set; }
        public cis[]? cis { get; set; }
    }
    public partial class proxyAddress
    {
        public string bnr { get; set; } = default!;
        public string floor { get; set; } = default!;
        public string gnr { get; set; } = default!;
        public string street { get; set; } = default!;
        public string street_no { get; set; } = default!;
        public string zip { get; set; } = default!;
        public string city { get; set; } = default!;
    }

    public partial class cis
    {
        public string name { get; set; } = default!;
        public string product { get; set; } = default!;
    }
}
