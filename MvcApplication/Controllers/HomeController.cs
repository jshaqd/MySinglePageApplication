﻿using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using MongoDB.Driver;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var mongoDb = MongoDatabase.Create(ConfigurationManager.AppSettings["MongoDBTimesheets"]);
            //var repository = mongoDb.GetCollection<Timesheet>(typeof(Timesheet).Name);
            //var timesheets = new List<Timesheet>
            //{
            //    new Timesheet { FirstName = "Christophe", LastName = "Geers", Month = 8, Year = 2012},
            //    new Timesheet { FirstName = "Ruben", LastName = "Geers", Month = 8, Year = 2012 }
            //};
            //foreach (var timesheet in timesheets)
            //    repository.Insert(timesheet);

            //repository.RemoveAll();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Comment()
        {
            return View();
        }

        public ActionResult Alumnus()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }

        public ActionResult Friends()
        {
            return View();
        }
    }
}
