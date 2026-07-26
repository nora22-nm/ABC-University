using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class TeacherController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult Index()
        {
            List<Teacher> teacherLst = new List<Teacher>();
            teacherLst = (from teacher in myDB.teachers
                          select teacher).ToList();
            return View(teacherLst);
        }

        [HttpGet]
        public ActionResult InsertTeacher()
        {

            return View();
        }
        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {
            myDB.teachers.Add(teacher);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherID == id
                   select data).FirstOrDefault();

            return View("Details", obj);
        }

        public ActionResult DeleteTeacher(int id)
        {
            Teacher obj = new Teacher();
            obj = (from data in myDB.teachers
                   where data.teacherID == id
                   select data).FirstOrDefault();

            myDB.teachers.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
        // GET: Teacher/Edit/5
        [HttpGet]
        public ActionResult EditTeacher(int id)
        {
            var obj = (from data in myDB.teachers
                       where data.teacherID == id
                       select data).FirstOrDefault();

            return View(obj);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult EditTeacher(Teacher teacher)
        {
            var obj = (from data in myDB.teachers
                       where data.teacherID == teacher.teacherID
                       select data).FirstOrDefault();

            if (obj != null)
            {
                obj.teacherName = teacher.teacherName;
                obj.teacherNo = teacher.teacherNo;

                myDB.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
   