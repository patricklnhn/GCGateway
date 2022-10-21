using System;
using System.Collections.Generic;

namespace WinAppMariaDBTest//.MariaDBDatabase
{
    public partial class Pop
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public int? AddressId { get; set; }
        public decimal? GeoLatitude { get; set; }
        public decimal? GeoLongtitude { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string UpdatedBy { get; set; } = null!;
        public int? ParentId { get; set; }
        public short? CategoryId { get; set; }
        public string? DocUrl { get; set; }
        public int? TechContactId { get; set; }
        public bool? Monitor { get; set; }
        public int? VpnId { get; set; }
        public int? VendorId { get; set; }
        public int? VesselTypeId { get; set; }
        public int? VesselCategoryId { get; set; }
        public string? RegNumber { get; set; }
    }
}
