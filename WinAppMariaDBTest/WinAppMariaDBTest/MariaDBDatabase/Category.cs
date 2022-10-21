using System;
using System.Collections.Generic;

namespace WinAppMariaDBTest//.MariaDBDatabase
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ParentId { get; set; }
        public string? Description { get; set; }
        public string? Responsible { get; set; }
        public string? Sec { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = null!;
    }
}
