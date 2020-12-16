using acikveriportal.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace acikveriportal.ViewModels
{
    public class DataSetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string OrganizationName { get; set; }
        public string FormatName { get; set; }
        public string LicenseName { get; set; }
        public string LabelName { get; set; }

        public List<DataSetFileDetail> DataSetFileDetails { get; set; }
    }
}