using System.ComponentModel.DataAnnotations;


namespace PointDatabase
{
    public class Room
    {
        public int Id { get; set; }
        public Building Building { get; set; }
        public int Floor { get; set; }
        public string RoomNumber { get; set; }
        public int ContactPersonID { get; set; }
        [StringLength(25)] 
        public string User { get; set; } = default!;
        public DateTime TS { get; set; }
    }
}
