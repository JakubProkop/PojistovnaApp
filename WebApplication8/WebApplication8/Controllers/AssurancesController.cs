using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    //kontroler vytvořený pomocí Entity Frameworku
    //zde jsem upravoval jen akci Create
    public class AssurancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssurancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assurances
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assurance.Include(a => a.PolicyHolder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assurances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assurance == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurance
                .Include(a => a.PolicyHolder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // GET: Assurances/Create
        public IActionResult Create(int HolderId, string FirstName, string LastName)
        {
            ViewBag.HolderId = HolderId;
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            return View();
        }

        // POST: Assurances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Amount,Payment")] Assurance assurance, string FirstName, string LastName)
        {
            //assurance.FirstName = "TEMP1";
            //assurance.LastName = "TEMP2";
            ViewBag.FirstName = FirstName;
            ViewBag.LastName = LastName;
            string temp = Request.Form["hID"];
            assurance.PolicyholderId = int.Parse(temp);
                _context.Add(assurance);
                await _context.SaveChangesAsync();

            /*_context.Add(assurance);
            _context.SaveChanges();*/
            return View(assurance);
        }

        // GET: Assurances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assurance == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurance.FindAsync(id);
            if (assurance == null)
            {
                return NotFound();
            }
            return View(assurance);
        }

        // POST: Assurances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PolicyholderId,Type,Amount,Payment")] Assurance assurance)
        {
            if (id != assurance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuranceExists(assurance.Id))
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
            return View(assurance);
        }

        // GET: Assurances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assurance == null)
            {
                return NotFound();
            }

            var assurance = await _context.Assurance
                .Include(a => a.PolicyHolder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assurance == null)
            {
                return NotFound();
            }

            return View(assurance);
        }

        // POST: Assurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assurance == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assurance'  is null.");
            }
            var assurance = await _context.Assurance.FindAsync(id);
            if (assurance != null)
            {
                _context.Assurance.Remove(assurance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuranceExists(int id)
        {
            return (_context.Assurance?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
