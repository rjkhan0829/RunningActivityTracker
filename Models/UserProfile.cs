using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningActivityTracker.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 500)]
        public double Weight { get; set; } // in kg

        [Range(1, 300)]
        public double Height { get; set; } // in cm

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age => DateTime.Now.Year - BirthDate.Year;

        [NotMapped]
        public double BMI => Weight / ((Height / 100) * (Height / 100));

        public ICollection<RunningActivity> RunningActivities { get; set; }
    }
}
