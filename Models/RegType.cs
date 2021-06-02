using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolRegistration.Models
{
    public partial class RegType
    {
        public RegType()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        public int StudentType { get; set; }
        [Required]
        [StringLength(10)]
        public string RegisterType { get; set; }

        [InverseProperty("StudentTypeNavigation")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
