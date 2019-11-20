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
    public class HeroesController : Controller
    {
        private OverwatchDBEntities db = new OverwatchDBEntities();

        // GET: Heroes
        public async Task<ActionResult> Index()
        {
            var heroes = db.Heroes.Include(h => h.Ability).Include(h => h.Weapon);
            return View(await heroes.ToListAsync());
        }

        // GET: Heroes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            ViewBag.AbilityID = new SelectList(db.Abilities, "AbilityID", "Type");
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponID", "Name");
            return View();
        }

        // POST: Heroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HeroID,Name,Role,WeaponID,AbilityID,Health,Image")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                db.Heroes.Add(hero);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AbilityID = new SelectList(db.Abilities, "AbilityID", "Type", hero.AbilityID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponID", "Name", hero.WeaponID);
            return View(hero);
        }

        // GET: Heroes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbilityID = new SelectList(db.Abilities, "AbilityID", "Type", hero.AbilityID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponID", "Name", hero.WeaponID);
            return View(hero);
        }

        // POST: Heroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HeroID,Name,Role,WeaponID,AbilityID,Health,Image")] Hero hero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hero).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AbilityID = new SelectList(db.Abilities, "AbilityID", "Type", hero.AbilityID);
            ViewBag.WeaponID = new SelectList(db.Weapons, "WeaponID", "Name", hero.WeaponID);
            return View(hero);
        }

        // GET: Heroes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hero hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return HttpNotFound();
            }
            return View(hero);
        }

        // POST: Heroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hero hero = await db.Heroes.FindAsync(id);
            db.Heroes.Remove(hero);
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
