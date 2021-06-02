using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Instructor = new HashSet<Instructor>();
            Registration = new HashSet<Registration>();
            StudentCourses = new HashSet<StudentCourses>();
            Students = new HashSet<Students>();
        }

        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Required]
        [StringLength(6)]
        public string CourseNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }
        [StringLength(255)]
        public string CourseDescription { get; set; }
        public int Units { get; set; }

        [InverseProperty("Course")]
        public virtual ICollection<Instructor> Instructor { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<Registration> Registration { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<StudentCourses> StudentCourses { get; set; }
        [InverseProperty("Course")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
