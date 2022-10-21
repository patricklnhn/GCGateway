using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGeneration.DotNet;


namespace PointDatabase
{
    public class VehicleType
    {
        public int Id { get; set; }
        [StringLength(25)] public string Name { get; set; } = default!;
        public bool Active { get; set; }
        [StringLength(25)]
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
