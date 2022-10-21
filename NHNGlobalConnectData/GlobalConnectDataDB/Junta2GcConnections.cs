namespace GlobalConnectDataDB
{
    /// <summary>
    /// Table for connections between Junta 
    /// database and ClobalConnect systems
    /// </summary>
    public class Junta2GcConnections
    {
        /// <summary>
        /// Internal Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id in Junta database
        /// </summary>
        public int JuntaId { get; set; }

        /// <summary>
        /// Id In GlobalConnect systems
        /// </summary>
        public int GcGabId { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime TS { get; set; }
    }
}