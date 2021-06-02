using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class Registration
    {
        [Key]
        [Column("RegistrationID")]
        public int RegistrationId { get; set; }
        public int StudentType { get; set; }
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Column("CourseID")]
        public int CourseId { get; set; }
        [Column("InstructorID")]
        public int InstructorId { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty(nameof(Courses.Registration))]
        public virtual Courses Course { get; set; }
        [ForeignKey(nameof(InstructorId))]
        [InverseProperty("Registration")]
        public virtual Instructor Instructor { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(Students.Registration))]
        public virtual Students Student { get; set; }
        [ForeignKey(nameof(StudentType))]
        [InverseProperty(nameof(RegType.Registration))]
        public virtual RegType StudentTypeNavigation { get; set; }
    }
}
