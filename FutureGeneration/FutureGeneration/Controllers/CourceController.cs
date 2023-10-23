using FutureGeneration.Models;
using FutureGeneration.Repository;
using Microsoft.AspNetCore.Mvc;
using static FutureGeneration.Data.Enums;
using System.Web;
using FutureGeneration.ViewMolel;

namespace FutureGeneration.Controllers
{
    public class CourceController : Controller
    {
        IRepository<Cource> CourceRepo;
        private IWebHostEnvironment hostingEnvironment;
        public CourceController(IRepository<Cource> _CourceRepo, IWebHostEnvironment _hostingEnvironment)
        {
            CourceRepo = _CourceRepo;
            hostingEnvironment = _hostingEnvironment;
        }
        //getall
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Cource> AllCources = CourceRepo.getAll().ToList();
            return View(AllCources);     
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CourceVM cource)
        {
            Cource newCource = new Cource();
            newCource.Name = cource.Name;
            newCource.Capacity = cource.Capacity;
            newCource.Status = cource.Status;
            newCource.StartDate = cource.StartDate;
            newCource.EndDate = cource.EndDate;
            newCource.Cost = cource.Cost;
            if (cource.CourseSyllabus != null)
            {
                string folder = "uploadedFiles";
                cource.ConvertCourseSyllabusURL = await UploadFile(folder, cource.CourseSyllabus);
            }
            newCource.CourseSyllabus = cource.ConvertCourseSyllabusURL;
            var raws = CourceRepo.Create(newCource);
            if(raws>0)
                return RedirectToAction("GetAll");
            return View();
        }
        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(hostingEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
        //getById
        [HttpGet]
        public ActionResult getById(int id)
        {
            Cource cource = CourceRepo.getById(id);
            return View(cource);
        }
        public ActionResult Edit(int id)
        {
            Cource cource = CourceRepo.getById(id);
            CourceVM courceVM = new CourceVM();
            courceVM.Capacity = cource.Capacity;
            courceVM.Cost = cource.Cost;
            courceVM.StartDate = cource.StartDate;
            courceVM.EndDate = cource.EndDate;
            courceVM.ConvertCourseSyllabusURL = cource.CourseSyllabus;
            courceVM.Status = cource.Status;
            return View(courceVM);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromRoute] int id, CourceVM cource)
        {
            Cource newCource = new Cource();
            newCource.Name = cource.Name;
            newCource.Capacity = cource.Capacity;
            newCource.Status = cource.Status;
            newCource.StartDate = cource.StartDate;
            newCource.EndDate = cource.EndDate;
            newCource.Cost = cource.Cost;
            if (cource.CourseSyllabus != null)
            {
                string folder = "uploadedFiles";
                cource.ConvertCourseSyllabusURL = await UploadFile(folder, cource.CourseSyllabus);
            }
            newCource.CourseSyllabus = cource.ConvertCourseSyllabusURL;
            var raws = CourceRepo.Edit(id, newCource);
            if (raws > 0)
            {
                return RedirectToAction("GetAll");
            }
            return View(cource);
        }
        public ActionResult Delete(int id)
        {
            var raws = CourceRepo.Delete(id);
            if (raws > 0)
            {
                return RedirectToAction("GetAll");
            }
            else if(raws == -2)
                return Content("No Cource Found With Selected Id .......");
            else if(raws == -3)
                return Content("the cource has Relations .......");
            return Content("An Error ....");
        }
    }
}
