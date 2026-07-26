using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class CourseController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult Index()
        {
            List<Course> courseLst = new List<Course>();
            courseLst = (from course in myDB.courses
                       select course).ToList();

            return View(courseLst);
        }

        [HttpGet]
        public ActionResult InsertCourse()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InsertCourse(Course course)
        {
            myDB.courses.Add(course);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Course obj = new Course();
            obj = (from data in myDB.courses
                   where data.courseID == id
                   select data).FirstOrDefault();

            return View("Details", obj);
        }

        public ActionResult DeleteCourse(int id)
        {
            Course obj = new Course();
            obj = (from data in myDB.courses
                   where data.courseID == id
                   select data).FirstOrDefault();

            myDB.courses.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            Course obj = (from data in myDB.courses
                          where data.courseID == id
                          select data).FirstOrDefault();

            return View(obj);  
        }

        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            var oldCourse = (from data in myDB.courses
                             where data.courseID == course.courseID
                             select data).FirstOrDefault();

            if (oldCourse != null)
            {
                oldCourse.courseName = course.courseName;
                oldCourse.isAvailable = course.isAvailable;

                myDB.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}