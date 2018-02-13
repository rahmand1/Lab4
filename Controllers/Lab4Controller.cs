using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class Lab4Controller : Controller
    {
        public IActionResult Index()
        {
            DateTime today = DateTime.Now;

            ViewData["Time"] = today.ToShortTimeString();
            ViewData["Date"] = today.ToShortDateString();

            if (today.Hour < 12)
            {
                ViewData["TimeofDay"] = "Morning";
            }
            else if (today.Hour < 8)
            {
                ViewData["TimeofDay"] = "Afternoon";
            }
            else
            {
                ViewData["TimeofDay"] = "Night";
            }

            DateTime daysLeft = DateTime.Parse("1/1/2019 12:00:01 AM");
            DateTime startDate = DateTime.Now;
            TimeSpan t = daysLeft - startDate;
            string countDown = string.Format("{0} days", t.Days);
            ViewData["TimeSpan"] = countDown;
            return View();

        }
        private static List<Profile> Profiles = new List<Profile>();

        public IActionResult About(int id)
        {

            if (Profiles.Count() < id)
            {
                var needed = id - Profiles.Count();
                for (var j = 0; j < needed; j++)
                {
                    Profile p = new Profile
                    {
                        Name = LoremNET.Lorem.Words(2),
                        Email = LoremNET.Lorem.Email(),
                        Bio = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                    };

                    Profiles.Add(p);
                }
            }

            if (Profiles.Count() == 0)
            {
                Profile p = new Profile
                {
                    Name = LoremNET.Lorem.Words(2),
                    Email = LoremNET.Lorem.Email(),
                    Bio = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                };

                Profiles.Add(p);
            }


            if (id == 0)
            {
                return View(Profiles);
            }
            else
            {
                var count = id;
                return View(Profiles.Take(count));
            }

        }

        public IActionResult Page3()
        {
            List<string> beveragesArray = new List<string>()
            {
                "Coffee",
                "Tea",
                "Coke",
                "Beer",
                "Wine"
            };

            ViewData["Header"] = "Beverages";

            return View(beveragesArray);
        }
    }
}