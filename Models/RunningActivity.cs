using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningActivityTracker.Models
{
    public class RunningActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [Range(0, double.MaxValue)]
        public double Distance { get; set; } // in km

        [NotMapped]
        public TimeSpan Duration => EndTime - StartTime;

        [NotMapped]
        public double AveragePace => Distance == 0 ? 0 : Duration.TotalHours / Distance;

        public int UserProfileId { get; set; }
        [ForeignKey("UserProfileId")]
        public UserProfile UserProfile { get; set; }
    }
}
