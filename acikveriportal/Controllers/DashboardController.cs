using acikveriportal.Models;
using acikveriportal.Models.Entity;
using acikveriportal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace acikveriportal.Controllers
{
    public class DashboardController : Controller
    {

        private db_AcikVeriPortalEntities01 _context = new db_AcikVeriPortalEntities01();



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(admin k)
        {
            var admin = _context.admin.FirstOrDefault(x => x.email == k.email && x.sifre == k.sifre);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(k.email, false);
                return RedirectToAction("All", "Dashboard");
            }


            ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış";
            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



        public ActionResult All()
        {
            var dataSetList = (from dataset in _context.DataSets
                               join category in _context.Categories on dataset.CategoryId equals category.Id
                               join organization in _context.Organizations on dataset.OrganizationId equals organization.Id
                               join format in _context.Formats on dataset.FormatId equals format.Id
                               join license in _context.Licenses on dataset.LicenseId equals license.Id
                               join label in _context.Labels on dataset.LabelId equals label.Id
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
                               }).ToList();
            return View(dataSetList);
        }

        public ActionResult CreateDataSet()
        {

            ViewBag.Organizations = _context.Organizations.Select(x => new Organization
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            ViewBag.Categories = _context.Categories.Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            ViewBag.Labels = _context.Labels.Select(x => new Label
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            ViewBag.Formats = _context.Formats.Select(x => new Format
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            ViewBag.Licenses = _context.Licenses.Select(x => new Models.License
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult DataSetCreated(DataSets dataSet)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateDataSet");
            }

            List<DataSetFileDetail> fileDetails = new List<DataSetFileDetail>();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    DataSetFileDetail fileDetail = new DataSetFileDetail()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        FileDataId = Guid.NewGuid().ToString()
                    };
                    fileDetails.Add(fileDetail);

                    var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.FileDataId + fileDetail.Extension);
                    file.SaveAs(path);
                }
            }
            dataSet.DataSetFileDetail = fileDetails;
            _context.DataSets.Add(dataSet);
            _context.SaveChanges();
            return RedirectToAction("All");
        }

        public ActionResult EditDataSet(int id)
        {

            ViewBag.Organizations = _context.Organizations.Select(x => new Organization
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            ViewBag.Categories = _context.Categories.Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            ViewBag.Labels = _context.Labels.Select(x => new Label
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            ViewBag.Formats = _context.Formats.Select(x => new Format
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            ViewBag.Licenses = _context.Licenses.Select(x => new Models.License
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            var dataSet = _context.DataSets.Where(x => x.Id == id).Select(x => new Models.DataSet
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                FormatId = x.FormatId,
                LabelId = x.LabelId,
                LicenseId = x.LicenseId,
                OrganizationId = x.OrganizationId,
                DataSetFileDetails = x.DataSetFileDetail.ToList()
            }).FirstOrDefault();

            return View(dataSet);
        }

        public FileResult Download(String p, String d)
        {
            return File(Path.Combine(Server.MapPath("~/App_Data/Upload/"), p), System.Net.Mime.MediaTypeNames.Application.Octet, d);
        }

        public ActionResult DeleteFile(string id)
        {
            DataSetFileDetail fileDetail = _context.DataSetFileDetail.FirstOrDefault(x => x.FileDataId == id);
            if (fileDetail == null)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return RedirectToAction("All");
            }

            //Remove from database
            _context.DataSetFileDetail.Remove(fileDetail);
            _context.SaveChanges();

            //Delete file from the file system
            var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.FileDataId + fileDetail.Extension);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction("EditDataSet", "Dashboard", new { id = fileDetail.DataSetId });
        }

        [HttpPost]
        public ActionResult DataSetEdited(DataSets newDataSet)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditDataSet", newDataSet);
            }

            DataSets oldDataSet = _context.DataSets.FirstOrDefault(x => x.Id == newDataSet.Id);
            oldDataSet.Title = newDataSet.Title;
            oldDataSet.Description = newDataSet.Description;
            oldDataSet.CategoryId = newDataSet.CategoryId;
            oldDataSet.OrganizationId = newDataSet.OrganizationId;
            oldDataSet.FormatId = newDataSet.FormatId;
            oldDataSet.LabelId = newDataSet.LabelId;
            oldDataSet.LicenseId = newDataSet.LicenseId;
            //New Files
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    DataSetFileDetail fileDetail = new DataSetFileDetail()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        FileDataId = Guid.NewGuid().ToString(),
                        DataSetId = oldDataSet.Id
                    };
                    var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.FileDataId + fileDetail.Extension);
                    file.SaveAs(path);
                    _context.Entry(fileDetail).State = EntityState.Added;
                }
            }

            _context.Entry(oldDataSet).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("All");

        }

        public ActionResult DeleteDataSet(int id)
        {
            var dataSet = _context.DataSets.Where(x => x.Id == id).Select(x => new Models.DataSet
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CategoryId = x.CategoryId,
                FormatId = x.FormatId,
                LabelId = x.LabelId,
                LicenseId = x.LicenseId,
                OrganizationId = x.OrganizationId,
                DataSetFileDetails = x.DataSetFileDetail.ToList()
            }).FirstOrDefault();

            return View(dataSet);
        }

        public ActionResult DataSetDeleted(int id)
        {
            DataSets dataSet = _context.DataSets.FirstOrDefault(x => x.Id == id);
            var dataSetList = _context.DataSetFileDetail.Where(x => x.DataSetId == id).ToList();

            foreach (var item in dataSetList)
            {
                DataSetFileDetail fileDetail = _context.DataSetFileDetail.FirstOrDefault(x => x.FileDataId == item.FileDataId);


                _context.DataSetFileDetail.Remove(fileDetail);
                _context.SaveChanges();

                var path = Path.Combine(Server.MapPath("~/App_Data/Upload/"), fileDetail.FileDataId + fileDetail.Extension);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            _context.DataSets.Remove(dataSet);
            _context.SaveChanges();

            return RedirectToAction("All");
        }

       

        public ActionResult Datasets()
        {
            return View();
        }

        #region Organization

        public ActionResult AllOrganization()
        {
            var organizations = _context.Organizations.Select(x => new Organization
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(organizations);
        }

        public ActionResult CreateOrganization() => View();

        [HttpPost]
        public ActionResult OrganizationCreated(Organizations organization)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateOrganization");
            }
            _context.Organizations.Add(organization);
            _context.SaveChanges();

            return RedirectToAction("AllOrganization");
        }

        public ActionResult EditOrganization(int id)
        {
            var organization = _context.Organizations.Where(x => x.Id == id).Select(x => new Models.Organization
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return View(organization);
        }

        [HttpPost]
        public ActionResult OrganizationEdited(Organizations newOrganization)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditOrganization", newOrganization);
            }

            Organizations oldOrganizations = _context.Organizations.FirstOrDefault(x => x.Id == newOrganization.Id);
            oldOrganizations.Name = newOrganization.Name;
            _context.SaveChanges();

            return RedirectToAction("AllOrganization");

        }

        public ActionResult DeleteOrganization(int id)
        {
            var organization = _context.Organizations.Where(x => x.Id == id).Select(x => new Models.Organization
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
            return View(organization);
        }

        public ActionResult OrganizationDeleted(int id)
        {
            Organizations organization = _context.Organizations.FirstOrDefault(x => x.Id == id);
            _context.Organizations.Remove(organization);
            _context.SaveChanges();

            return RedirectToAction("AllOrganization");
        }

        #endregion

        #region Category

        public ActionResult AllCategory()
        {
            var questions = _context.Categories.Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(questions);
        }

        public ActionResult CreateCategory() => View();

        [HttpPost]
        public ActionResult CategoryCreated(Categories category)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateCategory");
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("AllCategory");
        }

        public ActionResult EditCategory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).Select(x => new Category
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return View(category);
        }

        [HttpPost]
        public ActionResult CategoryEdited(Categories newCategory)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditCategory", newCategory);
            }

            Categories oldCategory = _context.Categories.FirstOrDefault(x => x.Id == newCategory.Id);
            oldCategory.Name = newCategory.Name;
            _context.SaveChanges();

            return RedirectToAction("AllCategory");

        }

        public ActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Where(x => x.Id == id).Select(x => new Models.Category
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
            return View(category);
        }

        public ActionResult CategoryDeleted(int id)
        {
            Categories category = _context.Categories.FirstOrDefault(x => x.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("AllCategory");
        }

        #endregion

        #region Label

        public ActionResult AllLabel()
        {
            var questions = _context.Labels.Select(x => new Label
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(questions);
        }

        public ActionResult CreateLabel() => View();

        [HttpPost]
        public ActionResult LabelCreated(Labels label)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateLabel");
            }
            _context.Labels.Add(label);
            _context.SaveChanges();

            return RedirectToAction("AllLabel");
        }

        public ActionResult EditLabel(int id)
        {
            var label = _context.Labels.Where(x => x.Id == id).Select(x => new Label
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return View(label);
        }

        [HttpPost]
        public ActionResult LabelEdited(Labels newLabel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditLabel", newLabel);
            }

            Labels oldLabel = _context.Labels.FirstOrDefault(x => x.Id == newLabel.Id);
            oldLabel.Name = newLabel.Name;
            _context.SaveChanges();

            return RedirectToAction("AllLabel");

        }

        public ActionResult DeleteLabel(int id)
        {
            var label = _context.Labels.Where(x => x.Id == id).Select(x => new Models.Label
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
            return View(label);
        }

        public ActionResult LabelDeleted(int id)
        {
            Labels label = _context.Labels.FirstOrDefault(x => x.Id == id);
            _context.Labels.Remove(label);
            _context.SaveChanges();

            return RedirectToAction("AllLabel");
        }

        #endregion

        #region Format

        public ActionResult AllFormat()
        {
            var formats = _context.Formats.Select(x => new Format
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(formats);
        }

        public ActionResult CreateFormat() => View();

        [HttpPost]
        public ActionResult FormatCreated(Formats format)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateFormat");
            }
            _context.Formats.Add(format);
            _context.SaveChanges();

            return RedirectToAction("AllFormat");
        }

        public ActionResult EditFormat(int id)
        {
            var format = _context.Formats.Where(x => x.Id == id).Select(x => new Format
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return View(format);
        }

        [HttpPost]
        public ActionResult FormatEdited(Formats newFormat)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditFormat", newFormat);
            }

            Labels oldFormat = _context.Labels.FirstOrDefault(x => x.Id == newFormat.Id);
            oldFormat.Name = newFormat.Name;
            _context.SaveChanges();

            return RedirectToAction("AllFormat");

        }

        public ActionResult DeleteFormat(int id)
        {
            var format = _context.Formats.Where(x => x.Id == id).Select(x => new Models.Format
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
            return View(format);
        }

        public ActionResult FormatDeleted(int id)
        {
            Formats format = _context.Formats.FirstOrDefault(x => x.Id == id);
            _context.Formats.Remove(format);
            _context.SaveChanges();

            return RedirectToAction("AllFormat");
        }

        #endregion

        #region License

        public ActionResult AllLicense()
        {
            var licenses = _context.Licenses.Select(x => new Models.License
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(licenses);
        }

        public ActionResult CreateLicense() => View();

        [HttpPost]
        public ActionResult LicenseCreated(Licenses license)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("CreateLicense");
            }
            _context.Licenses.Add(license);
            _context.SaveChanges();

            return RedirectToAction("AllLicense");
        }

        public ActionResult EditLicense(int id)
        {
            var license = _context.Licenses.Where(x => x.Id == id).Select(x => new Models.License
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();

            return View(license);
        }

        [HttpPost]
        public ActionResult LicenseEdited(Licenses newLicense)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditLicense", newLicense);
            }

            Licenses oldLicense = _context.Licenses.FirstOrDefault(x => x.Id == newLicense.Id);
            oldLicense.Name = newLicense.Name;
            _context.SaveChanges();

            return RedirectToAction("AllLicense");

        }

        public ActionResult DeleteLicense(int id)
        {
            var license = _context.Licenses.Where(x => x.Id == id).Select(x => new Models.License
            {
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefault();
            return View(license);
        }

        public ActionResult LicenseDeleted(int id)
        {
            Licenses license = _context.Licenses.FirstOrDefault(x => x.Id == id);
            _context.Licenses.Remove(license);
            _context.SaveChanges();

            return RedirectToAction("AllLicense");
        }

        #endregion

        #region DataRequest

        public ActionResult AllDataRequest()
        {

            var dataRequestList = (from dataRequest in _context.DataRequests
                                   join status in _context.Status on dataRequest.StatusId equals status.Id
                                   select new DataRequestViewModel
                                   {
                                       Id = dataRequest.Id,
                                       Title = dataRequest.Title,
                                       Description = dataRequest.Description,
                                       StatusName = status.Name
                                   }).ToList();

            return View(dataRequestList);
        }

      
        public ActionResult EditDataRequest(int id)
        {


            ViewBag.Statuses = _context.Status.Select(x => new Models.Status
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();


            var dataRequest = _context.DataRequests.Where(x => x.Id == id).Select(x => new Models.DataRequest
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StatusId = x.StatusId
            }).FirstOrDefault();

            return View(dataRequest);
        }

        [HttpPost]
        public ActionResult DataRequestEdited(DataRequest newDataRequest)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something went wrong!");
                return View("EditDataRequest", newDataRequest);
            }

            DataRequests oldDataRequest = _context.DataRequests.FirstOrDefault(x => x.Id == newDataRequest.Id);
            oldDataRequest.Title = newDataRequest.Title;
            oldDataRequest.Description = newDataRequest.Description;
            oldDataRequest.StatusId = newDataRequest.StatusId;
            _context.SaveChanges();

            return RedirectToAction("AllDataRequest");

        }

        public ActionResult DeleteDataRequest(int id)
        {
            var dataRequest = _context.DataRequests.Where(x => x.Id == id).Select(x => new Models.DataRequest
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                StatusId = x.StatusId
            }).FirstOrDefault();
            return View(dataRequest);
        }

        public ActionResult DataRequestDeleted(int id)
        {
            DataRequests dataRequest = _context.DataRequests.FirstOrDefault(x => x.Id == id);
            _context.DataRequests.Remove(dataRequest);
            _context.SaveChanges();

            return RedirectToAction("AllDataRequest");
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}