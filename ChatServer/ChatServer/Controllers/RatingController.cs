using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatServer.Data;
using ChatServer.Models;

namespace ChatServer.Controllers
{
    public class RatingController : Controller
    {
        private readonly ChatServerContext _context;
        private int _next;

        public RatingController(ChatServerContext context)
        {
            _context = context;
            var data = _context.Rating.ToList();
            if (data.Count > 0)
            {
                _next = data.Max(x => x.Id) + 1;
            }
        }

        // GET: Rating
        public async Task<IActionResult> Index()
        {
              return _context.Rating != null ? 
                          View(await _context.Rating.ToListAsync()) :
                          Problem("Entity set 'ChatServerContext.Rating'  is null.");
        }

        public async Task<IActionResult> Search(string query)
        {
            var data = await _context.Rating.ToListAsync();
            List<Rating> res = new List<Rating>();
            foreach (var r in data)
            {
                if (r.Text.Contains(query))
                {
                    res.Add(r);
                } 
            }
            return View(nameof(Index), res);
        }
        
        // GET: Rating/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Rating/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string comment, int score)
        {
            Rating rating = new Rating(++_next, name, comment, score);
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Rating/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Rating/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string name, string comment, int score)
        {
            Rating rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            rating.Name = name;
            rating.Text = comment;
            rating.Score = score;
            rating.When = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
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
            return View(rating);
        }

        // GET: Rating/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rating == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Rating/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rating == null)
            {
                return Problem("Entity set 'ChatServerContext.Rating'  is null.");
            }
            var rating = await _context.Rating.FindAsync(id);
            if (rating != null)
            {
                _context.Rating.Remove(rating);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
          return (_context.Rating?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
