using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectFai.Models
{

    [Table("Rooms")]

    public class Room
    {
        [Key]
        public int rId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public string RoomLoc { get; set; } = string.Empty;
        public int RoomCapscity { get; set; }
    }
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
    }
}

