using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acikveriportal.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide full name!")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

    }
}