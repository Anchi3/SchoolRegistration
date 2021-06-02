using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class Students
    {
        public Students()
        {
            Registration = new HashSet<Registration>();
            StudentCourses = new HashSet<StudentCourses>();
        }

        [Key]
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Column("CourseID")]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Courses.Students))]
        public virtual Courses Course { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<Registration> Registration { get; set; }
        [InverseProperty("Student")]
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
    }
}
