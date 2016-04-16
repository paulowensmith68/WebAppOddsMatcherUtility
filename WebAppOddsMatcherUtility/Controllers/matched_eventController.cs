using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppOddsMatcherUtility.Models;
using PagedList;


namespace WebAppOddsMatcherUtility.Controllers
{
    public class matched_eventController : Controller
    {
        private oddsmatchingEntities db = new oddsmatchingEntities();

        // GET: matched_event
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DetailsSortParm = sortOrder == "details" ? "details_desc" : "details";
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            ViewBag.BetSortParm = sortOrder == "bet" ? "bet_desc" : "bet";
            ViewBag.MarketSortParm = sortOrder == "market" ? "market_desc" : "market";
            ViewBag.BookmakerSortParm = sortOrder == "bookmaker" ? "bookmaker_desc" : "bookmaker";
            ViewBag.BackSortParm = sortOrder == "back" ? "back_desc" : "back";
            ViewBag.ExchangeSortParm = sortOrder == "exchange" ? "exchange_desc" : "exchange";
            ViewBag.LaySortParm = sortOrder == "lay" ? "lay_desc" : "lay";
            ViewBag.SizeSortParm = sortOrder == "size" ? "size_desc" : "size";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var matched = from s in db.matched_event
                          select s;

            switch (sortOrder)
            {
                case "Date":
                    matched = matched.OrderBy(s => s.eventDate);
                    break;
                case "date_desc":
                    matched = matched.OrderByDescending(s => s.eventDate);
                    break;
                case "rating":
                    matched = matched.OrderBy(s => s.rating);
                    break;
                case "rating_desc":
                    matched = matched.OrderByDescending(s => s.rating);
                    break;
                case "details":
                    matched = matched.OrderBy(s => s.details);
                    break;
                case "details_desc":
                    matched = matched.OrderByDescending(s => s.details);
                    break;
                case "bet":
                    matched = matched.OrderBy(s => s.betName);
                    break;
                case "bet_desc":
                    matched = matched.OrderByDescending(s => s.betName);
                    break;
                case "market":
                    matched = matched.OrderBy(s => s.marketName);
                    break;
                case "market_desc":
                    matched = matched.OrderByDescending(s => s.marketName);
                    break;
                case "bookmaker":
                    matched = matched.OrderBy(s => s.bookmaker);
                    break;
                case "bookmaker_desc":
                    matched = matched.OrderByDescending(s => s.bookmaker);
                    break;
                case "back":
                    matched = matched.OrderBy(s => s.back);
                    break;
                case "back_desc":
                    matched = matched.OrderByDescending(s => s.back);
                    break;
                case "exchange":
                    matched = matched.OrderBy(s => s.exchange);
                    break;
                case "exchange_desc":
                    matched = matched.OrderByDescending(s => s.exchange);
                    break;
                case "lay":
                    matched = matched.OrderBy(s => s.lay);
                    break;
                case "lay_desc":
                    matched = matched.OrderByDescending(s => s.lay);
                    break;
                case "size":
                    matched = matched.OrderBy(s => s.size);
                    break;
                case "size_desc":
                    matched = matched.OrderByDescending(s => s.size);
                    break;
                default:
                        matched = matched.OrderByDescending(s => s.rating);
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(matched.ToPagedList(pageNumber, pageSize));
        }

        // GET: matched_event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matched_event matched_event = db.matched_event.Find(id);
            if (matched_event == null)
            {
                return HttpNotFound();
            }
            return View(matched_event);
        }

        // GET: matched_event/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: matched_event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,eventDate,sport,details,betName,marketName,rating,info,bookmaker,back,exchange,lay,size,betfairEventTypeId,betfairMarketTypeCode,competitionName,countryCode,timezone,n,ut,del")] matched_event matched_event)
        {
            if (ModelState.IsValid)
            {
                db.matched_event.Add(matched_event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(matched_event);
        }

        // GET: matched_event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matched_event matched_event = db.matched_event.Find(id);
            if (matched_event == null)
            {
                return HttpNotFound();
            }
            return View(matched_event);
        }

        // POST: matched_event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,eventDate,sport,details,betName,marketName,rating,info,bookmaker,back,exchange,lay,size,betfairEventTypeId,betfairMarketTypeCode,competitionName,countryCode,timezone,n,ut,del")] matched_event matched_event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matched_event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(matched_event);
        }

        // GET: matched_event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matched_event matched_event = db.matched_event.Find(id);
            if (matched_event == null)
            {
                return HttpNotFound();
            }
            return View(matched_event);
        }

        // POST: matched_event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            matched_event matched_event = db.matched_event.Find(id);
            db.matched_event.Remove(matched_event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
