using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bidder;
using bidder.Data;


//Testting

namespace bidder.Controllers
{
    public class AuctionController : Controller
    {
        private readonly SiteContext _context;

        public AuctionController(SiteContext context)
        {
            _context = context;
        }

        // GET: Auction
        public async Task<IActionResult> Index()
        {
            var siteContext = _context.Auctions.Include(a => a.seller);
            return View(await siteContext.ToListAsync());
        }

        // GET: Auction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.seller)
                .FirstOrDefaultAsync(m => m.auctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // GET: Auction/Create
        public IActionResult Create()
        {
            ViewData["sellerID"] = new SelectList(_context.Users, "userID", "userID");
            return View();
        }

        // POST: Auction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("auctionID,itemName,itemDescription,startingBid,reservePrice,auctionStart,auctionEnd,condition,category,sellerID")] Auction auction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["sellerID"] = new SelectList(_context.Users, "userID", "userID", auction.sellerID);
            return View(auction);
        }

        // GET: Auction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }
            ViewData["sellerID"] = new SelectList(_context.Users, "userID", "userID", auction.sellerID);
            return View(auction);
        }

        // POST: Auction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("auctionID,itemName,itemDescription,startingBid,reservePrice,auctionStart,auctionEnd,condition,category,sellerID")] Auction auction)
        {
            if (id != auction.auctionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionExists(auction.auctionID))
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
            ViewData["sellerID"] = new SelectList(_context.Users, "userID", "userID", auction.sellerID);
            return View(auction);
        }

        // GET: Auction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auction = await _context.Auctions
                .Include(a => a.seller)
                .FirstOrDefaultAsync(m => m.auctionID == id);
            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        // POST: Auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auctions == null)
            {
                return Problem("Entity set 'SiteContext.Auctions'  is null.");
            }
            var auction = await _context.Auctions.FindAsync(id);
            if (auction != null)
            {
                _context.Auctions.Remove(auction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionExists(int id)
        {
          return (_context.Auctions?.Any(e => e.auctionID == id)).GetValueOrDefault();
        }
    }
}
