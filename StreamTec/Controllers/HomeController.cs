﻿using Microsoft.AspNetCore.Mvc;
using StreamTec.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace StreamTec.Controllers
{
    public class HomeController : Controller
    {
        private readonly WelTecContext _context;

        public HomeController(WelTecContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Timetable()
        {
            // TimeTable Dictionary <majorname, a list of streams>
            Dictionary<string, List<Models.Stream>> streamDic = new Dictionary<string, List<Models.Stream>>();

            // A Dictionary for major names and its code
            Dictionary<string, string> majorDic = new Dictionary<string, string>()
            {
                { "Cyber Security", "CS" },
                { "Data Science", "DS"},
                { "Interaction Design", "ID" },
                { "Networking and Infra", "NI" },
                { "Software Development", "SD" },
                { "Other", "IT"},
            };

            // A list of streams
            List<Models.Stream> streamList = new List<Models.Stream>();

            foreach (KeyValuePair<string, string> major in majorDic)
            {
                streamDic.Add(major.Key, streamList.Where(s => s.StreamID.StartsWith(major.Value)).ToList());
                streamList.Clear();
            }

            return View(streamDic);
            //return View(_context.Streams.ToList());
        }

        // Register Action for registring a student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("StudentId,Email")] Student student)
        {
            try
            {
                // Add a student details to database and redirect user to homepage
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    TempData["message"] = string.Format("Successfully Registered with Student ID: {0}", student.StudentId);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student)
        {
            try
            {
                // Validate a student details
                if (ModelState.IsValid)
                {
                    using (_context)
                    {
                        var obj = _context.Students.Where(s => s.StudentId.Equals(student.StudentId) && s.Email.Equals(student.Email)).FirstOrDefault();
                        if (obj != null)
                        {
                            // Add a student details to session
                            HttpContext.Session.SetString("_StudentId", obj.StudentId.ToString());
                            HttpContext.Session.SetString("_Email", obj.Email.ToString());
                            return RedirectToAction("Timetable", "Home");
                        }
                    }
                }
                TempData["message"] = "Invalid student details";
                return RedirectToAction("Index", "Home");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["message"] = "Successfully logged out";
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}