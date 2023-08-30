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
    public class PolicyHoldersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PolicyHoldersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PolicyHolders
        public async Task<IActionResult> Index()
        {
              return _context.PolicyHolder != null ? 
                          View(await _context.PolicyHolder.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PolicyHolder'  is null.");
        }

        public ApplicationDbContext Get_context()
        {
            return _context;
        }

        // GET: PolicyHolders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //List<Assurance> assurances = _context.Assurance.ToList();
            
            if (id == null || _context.PolicyHolder == null)
            {
                return NotFound();
            }

            var policyHolder = await _context.PolicyHolder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyHolder == null)
            {
                return NotFound();
            }
            var assurance = _context.Assurance.ToList();
            ViewBag.Assurance = assurance;
            return View(policyHolder);
        }

        // GET: PolicyHolders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicyHolders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,TelephoneNumber,Street,City,PostCode")] PolicyHolder policyHolder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policyHolder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policyHolder);
        }

        // GET: PolicyHolders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PolicyHolder == null)
            {
                return NotFound();
            }

            var policyHolder = await _context.PolicyHolder.FindAsync(id);
            if (policyHolder == null)
            {
                return NotFound();
            }
            return View(policyHolder);
        }

        // POST: PolicyHolders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,TelephoneNumber,Street,City,PostCode")] PolicyHolder policyHolder)
        {
            if (id != policyHolder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyHolder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyHolderExists(policyHolder.Id))
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
            return View(policyHolder);
        }

        // GET: PolicyHolders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PolicyHolder == null)
            {
                return NotFound();
            }

            var policyHolder = await _context.PolicyHolder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyHolder == null)
            {
                return NotFound();
            }

            return View(policyHolder);
        }

        // POST: PolicyHolders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PolicyHolder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PolicyHolder'  is null.");
            }
            var policyHolder = await _context.PolicyHolder.FindAsync(id);
            if (policyHolder != null)
            {
                _context.PolicyHolder.Remove(policyHolder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyHolderExists(int id)
        {
          return (_context.PolicyHolder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
