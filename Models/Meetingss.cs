using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjectFai.Models
{
    [Table("Meeting")]

    public class Meetingss
    {
        [Key]
        public int mId { get; set; }
        [Required]
        public string? mDetails { get; set; }
        [Required]
        public DateTime mDate { get; set; }
        [Required]
        public TimeSpan startTime { get; set; }
        [Required]
        public TimeSpan endTime { get; set; }
        [Required]
        public int? EmpId {  get; set; }
        public virtual Employee? Employee{ get; set; }
        public int? rId { get; set; }
        public virtual Room? Room { get; set; }

        public string? campusLoc { get; set; }

    }
    public class MDbContext : DbContext

    {
        public MDbContext(DbContextOptions<MDbContext> options) : base(options) { }
        public DbSet<Meetingss> meetingsses { get; set; }
    }
}

