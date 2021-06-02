using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        [Column("InstructorID")]
        public int InstructorId { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("CourseID")]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Courses.Instructor))]
        public virtual Courses Course { get; set; }
        [InverseProperty("Instructor")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
