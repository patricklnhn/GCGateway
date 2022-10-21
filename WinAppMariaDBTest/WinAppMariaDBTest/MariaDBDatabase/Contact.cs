using System;
using System.Collections.Generic;

namespace WinAppMariaDBTest//.MariaDBDatabase
{
    public partial class Contact
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;
    }
}
