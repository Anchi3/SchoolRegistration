using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class StudentCourses
    {
        [Key]
        public int Id { get; set; }
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Column("CourseID")]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Courses.StudentCourses))]
        public virtual Courses Course { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Students.StudentCourses))]
        public virtual Students Student { get; set; }
    }
}
