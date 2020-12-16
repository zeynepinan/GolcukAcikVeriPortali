using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acikveriportal.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Ad")]
        public string Name { get; set; }

    }
}