using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Overwatch_Maker.Models;

namespace Overwatch_Maker.Controllers
{
    public class AbilitiesController : Controller
    {
        private OverwatchDBEntities db = new OverwatchDBEntities();

        // GET: Abilities
        public async Task<ActionResult> Index()
        {
            return View(await db.Abilities.ToListAsync());
        }

        // GET: Abilities/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = await db.Abilities.FindAsync(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // GET: Abilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Abilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AbilityID,Type,Name,Description,Duration,Strenght")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Abilities.Add(ability);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ability);
        }

        // GET: Abilities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = await db.Abilities.FindAsync(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Abilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AbilityID,Type,Name,Description,Duration,Strenght")] Ability ability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ability).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ability);
        }

        // GET: Abilities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ability ability = await db.Abilities.FindAsync(id);
            if (ability == null)
            {
                return HttpNotFound();
            }
            return View(ability);
        }

        // POST: Abilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ability ability = await db.Abilities.FindAsync(id);
            db.Abilities.Remove(ability);
            await db.SaveChangesAsync();
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
