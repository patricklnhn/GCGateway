using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GlobalConnectDataDB
{
    /// <summary>
    /// Table for coverage checks  
    /// performed in GC API
    /// </summary>
    public class GcCoverageCheck
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id In GlobalConnect systems
        /// </summary>
        public int GcGabId { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime TS { get; set; }

        /// <summary>
        /// Result of this covarage chech.
        /// Result from GlobalConnect
        /// </summary>
        public string ResultJson { get; set; } = default!;
    }
}
