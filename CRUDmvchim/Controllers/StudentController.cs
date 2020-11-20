using CRUDmvchim.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDmvchim.Controllers
{
    public class StudentController : Controller
    {
        RegistrationEntities dbobj = new RegistrationEntities();
        public ActionResult Student(detail obj)
        {
            if (obj != null)
                return View(obj);
            else
                return View();
        }
        [HttpPost]
        public ActionResult AddStudent(detail model)
        {
            if (ModelState.IsValid)
            {
                detail obj = new detail();
                obj.firstname = model.firstname;
                obj.lastname = model.lastname;
                obj.email = model.email;
                obj.rollno = model.rollno;
                obj.student_address = model.student_address;
                obj.student_state = model.student_state;
                obj.mobile = model.mobile;
                dbobj.details.Add(obj);
                dbobj.SaveChanges();
            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult Studentlist()
        {
            var res = dbobj.details.ToList();
            return View(res);
        }
        public ActionResult Delete(int id)
        {
            var res = dbobj.details.Where(x => x.ID == id).First();
            dbobj.details.Remove(res);
            dbobj.SaveChanges();
            var list = dbobj.details.ToList();
           
            return View("Studentlist",list);
        }

    }
}