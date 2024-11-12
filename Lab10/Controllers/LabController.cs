using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab10.Controllers
{
    public class LabController : Controller
    {
        // GET: Lab
        public ActionResult ListOfPeople()
        {
            List<Person> people = new List<Person>();

            using (var db = new SurveyDBEntities())
            {
                people = db.Person
                    .OrderByDescending(x => x.Age)
                    .ThenBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .ToList();
            }

            return View(people);
        }
        [HttpGet]
        public ActionResult PersonDetails(Guid personId)
        {
            Person model = new Person();
            using (var db = new SurveyDBEntities())
            {
                model = db.Person.Find(personId); 
            }

           
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }
    }
}