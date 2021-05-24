using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cv_melon1.Models;

namespace cv_melon1.Controllers
{
   
    public class ReadFileController : Controller
    {
        public IActionResult ReadFile(string input)
        {
            var person = new CV();
            string[] words = input.Split(' '); //TODO: verify the XML syntax and check if all tags are closed correctly

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0] == '<' && words[i][1] != '/')
                {
                    if (words[i].Contains("FirstName"))
                    {
                        person.fisrtName = words[i + 1];
                    }

                    if (words[i].Contains("LastName"))
                    {
                        person.lastName = words[i + 1];
                    }

                    if (words[i].Contains("Education"))
                    {
                        person.studyinPlaces.Add(new StudyPlace(words[i + 1]));
                    }
                    if (words[i].Contains("Work"))
                    {
                        person.workingPlaces.Add(new WorkingPlace(words[i + 1]));
                    }
                }
            }

            return View();
        }


    }
}
