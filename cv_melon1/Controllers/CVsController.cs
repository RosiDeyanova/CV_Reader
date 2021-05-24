using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cv_melon1.Data;
using cv_melon1.Models;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace cv_melon1.Controllers
{
    public class CVsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CVsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CV
                .Select(x => new IndexDTO
                {
                    id = x.id,
                    fisrtName = x.fisrtName,
                    lastName = x.lastName,
                    workingPlaces = string.Join(", ", x.workingPlaces.Select(x => x.place)),
                    studyinPlaces = string.Join(", ", x.studyinPlaces.Select(x => x.place))
                }).ToListAsync());
        }



        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }
        public async Task<IActionResult> ShowSearchResults(String CVname)
        {
            return View("SearchResults",await _context.CV.
                Where(x => x.fisrtName.Contains(CVname) ||
                           x.lastName.Contains(CVname)).ToListAsync());
        }

        // GET: CVs/Details/5
        public IActionResult Details(string id)
        {
            //return View(await _context.CV
            //  .Select(x => new IndexDTO
            //  {
            //      fileText = x.fileText
            //  }).AnyAsync());
            //return View();
            return View("Details");
        }

        // GET: CVs/Create
        public IActionResult Create()
        {
           
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(reader.ReadLine());
            }

            var person = new CV();
            string[] words = result.ToString().Trim().Split(Environment.NewLine); //TODO: verify the XML syntax and check if all tags are closed correctly
            string fullText = result.ToString().Trim();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i][0] == '<' && words[i][1] != '/')
                {
                    if (words[i].Contains("FirstName"))
                    {
                        person.fisrtName = words[i].Substring(11, words[i].Length-23);
                        
                    }

                    if (words[i].Contains("LastName"))
                    {
                        person.lastName = words[i].Substring(10, words[i].Length - 21);
                    }

                    if (words[i].Contains("Education"))
                    {
                        var a = new StudyPlace(words[i].Substring(11, words[i].Length-23).Trim());
                        person.studyinPlaces.Add(a);
                    }
                    if (words[i].Contains("Work"))
                    {
                        person.workingPlaces.Add(new WorkingPlace(words[i].Substring(6, words[i].Length - 13)));
                    }
                    person.fileText =fullText;
                }
            }

            _context.Add(person);
            _context.SaveChanges();

            return Ok();
        }

        // GET: CVs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CV.FindAsync(id);
            if (cV == null)
            {
                return NotFound();
            }
            return View(cV);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("fisrtName,lastName,id")] CV cV)
        {
            if (id != cV.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CVExists(cV.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cV);
        }

        // GET: CVs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cV = await _context.CV
                .FirstOrDefaultAsync(m => m.id == id);
            if (cV == null)
            {
                return NotFound();
            }

            return View(cV);
        }

        // POST: CVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cV = await _context.CV.FindAsync(id);
            _context.CV.Remove(cV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CVExists(string id)
        {
            return _context.CV.Any(e => e.id == id);
        }
    }
}
