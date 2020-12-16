using acikveriportal.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace acikveriportal.Models
{
    public class DataSet
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        
        [Display(Name = "Organizasyon")]
        public int OrganizationId { get; set; }
        
        [Display(Name = "Format")]
        public int FormatId { get; set; }

        [Display(Name = "Lisans")]
        public int LicenseId { get; set; }

        [Display(Name = "Etiket")]
        public int LabelId { get; set; }

        public  List<DataSetFileDetail> DataSetFileDetails { get; set; }
    }
}