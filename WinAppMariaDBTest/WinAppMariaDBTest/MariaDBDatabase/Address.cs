using System;
using System.Collections.Generic;

namespace WinAppMariaDBTest//.MariaDBDatabase
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = null!;
        public string? StreetNo { get; set; }
        /// <summary>
        /// entrance / floor / room
        /// </summary>
        public string Floor { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string? Room { get; set; }
        public string? Gnr { get; set; }
        public string? Bnr { get; set; }
    }
}
