using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using acikveriportal.Models.Entity;
using acikveriportal.ViewModels;
using PagedList;


namespace acikveriportal.Controllers
{
    public class HomeController : Controller
    {
        db_AcikVeriPortalEntities01 db = new db_AcikVeriPortalEntities01();
        // GET: Home
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult DataSets(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            var dataSetList = (from dataset in db.DataSets
                               join category in db.Categories on dataset.CategoryId equals category.Id
                               join organization in db.Organizations on dataset.OrganizationId equals organization.Id
                               join format in db.Formats on dataset.FormatId equals format.Id
                               join license in db.Licenses on dataset.LicenseId equals license.Id
                               join label in db.Labels on dataset.LabelId equals label.Id
                               select new DataSetViewModel
                               {
                                   Id = dataset.Id,
                                   Title = dataset.Title,
                                   Description = dataset.Description,
                                   LabelName = label.Name,
                                   CategoryName = category.Name,
                                   OrganizationName = organization.Name,
                                   FormatName = format.Name,
                                   LicenseName = license.Name
                               });

            if (!String.IsNullOrEmpty(Search_Data))
            {
                dataSetList = dataSetList.Where(stu => stu.Title.ToUpper().Contains(Search_Data.ToUpper()) || stu.CategoryName.ToUpper().Contains(Search_Data.ToUpper()) || stu.OrganizationName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            dataSetList = dataSetList.OrderBy(stu => stu.Description);

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(dataSetList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

        public ActionResult CreateDataRequest()
        {


            ViewBag.Statuses = db.Status.Select(x => new Models.Status
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult DataRequestCreated(DataRequests dataRequest)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateDataRequest");
            }
            db.DataRequests.Add(dataRequest);
            db.SaveChanges();

            return RedirectToAction("DataRequests", "Home");
        }

        public ActionResult DataRequests(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Name_Description" : "";

            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }

            ViewBag.FilterValue = Search_Data;
            var dataRequestList = (from dataRequest in db.DataRequests
                                   join status in db.Status on dataRequest.StatusId equals status.Id
                                   select new DataRequestViewModel
                                   {
                                       Id = dataRequest.Id,
                                       Title = dataRequest.Title,
                                       Description = dataRequest.Description,
                                       StatusName = status.Name
                                   });

            if (!String.IsNullOrEmpty(Search_Data))
            {
                dataRequestList = dataRequestList.Where(stu => stu.Title.ToUpper().Contains(Search_Data.ToUpper()) || stu.Description.ToUpper().Contains(Search_Data.ToUpper()) || stu.StatusName.ToUpper().Contains(Search_Data.ToUpper()));
            }

            dataRequestList = dataRequestList.OrderBy(stu => stu.Description);

            int Size_Of_Page = 10;
            int No_Of_Page = (Page_No ?? 1);
            return View(dataRequestList.ToPagedList(No_Of_Page, Size_Of_Page));
        }

       
        public ActionResult DataSetDetails(int id)
        {

            var dataSet = (from dataset in db.DataSets.Where(x => x.Id == id)
                           join category in db.Categories on dataset.CategoryId equals category.Id
                           join organization in db.Organizations on dataset.OrganizationId equals organization.Id
                           join format in db.Formats on dataset.FormatId equals format.Id
                           join license in db.Licenses on dataset.LicenseId equals license.Id
                           join label in db.Labels on dataset.LabelId equals label.Id
                           select new DataSetViewModel
                           {
                               Id = dataset.Id,
                               Title = dataset.Title,
                               Description = dataset.Description,
                               LabelName = label.Name,
                               CategoryName = category.Name,
                               OrganizationName = organization.Name,
                               FormatName = format.Name,
                               LicenseName = license.Name,
                               DataSetFileDetails = dataset.DataSetFileDetail.ToList()
                           }).FirstOrDefault();

            return View(dataSet);
        }

        public ActionResult announcements()
        {
            return View();
        }
        public ActionResult organization()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact(contact model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad & Soyad: " + model.Name);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Subject);
                body.AppendLine("Mesaj: " + model.Message);
                Mail.MailSender(body.ToString());
            }
            return View();
        }

    }
}