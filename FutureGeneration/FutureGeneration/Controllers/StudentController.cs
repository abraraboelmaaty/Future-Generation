using FutureGeneration.Models;
using FutureGeneration.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FutureGeneration.Controllers
{
    public class StudentController : Controller
    {
        IRepository<Student> StudentRepo;
        IRepository<Cource> CourceRepo;
        IRepositoryAssignStudent<StudentCource> StuCrsRepo;
        public StudentController(IRepository<Student> _StudentRepo, IRepository<Cource> _CourceRepo, IRepositoryAssignStudent<StudentCource> _StuCrsRepo)
        {
            StudentRepo = _StudentRepo;
            CourceRepo = _CourceRepo;
            StuCrsRepo = _StuCrsRepo;
        }
        //getall
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Student> AllStudent = StudentRepo.getAll().ToList();
            return View(AllStudent);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            var raws = StudentRepo.Create(student);
            if (raws > 0)
                return RedirectToAction("GetAll");
            return View();
        }
        //getById
        [HttpGet]
        public ActionResult getById(int id)
        {
            Student student = StudentRepo.getById(id);
            return View(student);
        }
        public ActionResult Edit(int id)
        {
            Student student = StudentRepo.getById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit([FromRoute] int id, Student student)
        {
            var raws = StudentRepo.Edit(id,student);
            if (raws > 0)
            {
                return RedirectToAction("GetAll");
            }
            return View(student);
        }
        public ActionResult Delete(int id)
        {
            var raws = StudentRepo.Delete(id);
            if (raws > 0)
            {
                return RedirectToAction("GetAll");
            }
            else if (raws == -2)
                return Content("No Student Found With Selected Id .......");
            else if (raws == -3)
                return Content("the student has Relations .......");
            return Content("An Error ....");
        }
        public ActionResult AssignStudentToCource(int id)
        {
            List<Cource> Cources = CourceRepo.getAll().ToList();
            var student = StudentRepo.getById(id);
            ViewBag.Cources = Cources;
            ViewBag.StudentName = student.Name;
            ViewBag.StudentId = student.ID;
            return View(student);
        }
        [HttpPost]
        public ActionResult AssignStudentToCource([FromRoute] int id, int CourceId)
        {
            StudentCource stdcrs = new StudentCource();
            stdcrs.StudentId = id;
            stdcrs.CourceId = CourceId;
            var raws = StuCrsRepo.Create(stdcrs);
            if (raws > 0)
                return RedirectToAction("GetAll");
            return View();
        }
    }
}
