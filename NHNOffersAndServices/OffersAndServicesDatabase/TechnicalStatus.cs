﻿using System.ComponentModel.DataAnnotations;

namespace OffersAndServicesDatabase
{
    public class TechnicalStatus
    {
        public int Id { get; set; }
        [StringLength(50)] public string Name { get; set; } = default!;
        [StringLength(25)] public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
