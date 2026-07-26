using ABC_University.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC_University.Controllers
{
    public class RoomController : Controller
    {
        ABCDbContext myDB = new ABCDbContext();
        public ActionResult Index()
        {
            List<Room> roomLst = new List<Room>();
            roomLst = (from room in myDB.rooms
                         select room).ToList();

            return View(roomLst);
        }

        [HttpGet]
        public ActionResult InsertRoom()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InsertRoom(Room room)
        {
            myDB.rooms.Add(room);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetDetails(int id)
        {
            Room obj = new Room();
            obj = (from data in myDB.rooms
                   where data.roomID == id
                   select data).FirstOrDefault();

            return View("Details", obj);
        }

        public ActionResult DeleteRoom(int id)
        {
            Room obj = new Room();
            obj = (from data in myDB.rooms
                   where data.roomID == id
                   select data).FirstOrDefault();

            myDB.rooms.Remove(obj);
            myDB.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            var obj = (from data in myDB.rooms
                       where data.roomID == id
                       select data).FirstOrDefault();

            return View(obj); // يفتح صفحة التعديل
        }
        [HttpPost]
        public ActionResult EditRoom(Room room)
        {
            var obj = (from data in myDB.rooms
                       where data.roomID == room.roomID
                       select data).FirstOrDefault();

            if (obj != null)
            {
                obj.roomName = room.roomName;
                obj.roomSize = room.roomSize;
                obj.isAvailable = room.isAvailable;
                obj.location = room.location;

                myDB.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}