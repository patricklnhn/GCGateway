using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVClient
{
    /// <summary>
    /// Class for transferring addresses from
    /// kartverket search to search with the GlobalConnect API
    /// </summary>
    internal class tmpAddress
    {

        public string addrText { get; set; } = default!;
        public string pNr { get; set; } = default!;
        public string pSted { get; set; } = default!;


        /// <summary>
        /// Overriding ToString() in order to 
        /// concatenate address info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return addrText + " -  " + pNr + " " + pSted;
        }
    }
}
