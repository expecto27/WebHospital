using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class Doctor_has_PatientController : Controller
    {
        private HospitalEntities db = new HospitalEntities();

        // GET: Doctor_has_Patient
        public ActionResult Index()
        {
            var doctor_has_Patient = db.Doctor_has_Patient.Include(d => d.Doctor).Include(d => d.Patient);
            return View(doctor_has_Patient.ToList());
        }

        // GET: Doctor_has_Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_has_Patient doctor_has_Patient = db.Doctor_has_Patient.Find(id);
            if (doctor_has_Patient == null)
            {
                return HttpNotFound();
            }
            return View(doctor_has_Patient);
        }

        // GET: Doctor_has_Patient/Create
        public ActionResult Create()
        {
            ViewBag.Doctor_idDoctor = new SelectList(db.Doctor, "idDoctor", "fullname");
            ViewBag.Patient_idPatient = new SelectList(db.Patient, "idPatient", "fullname");
            return View();
        }

        // POST: Doctor_has_Patient/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Doctor_idDoctor,Patient_idPatient,datee,price")] Doctor_has_Patient doctor_has_Patient)
        {
            if (ModelState.IsValid)
            {
                db.Doctor_has_Patient.Add(doctor_has_Patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Doctor_idDoctor = new SelectList(db.Doctor, "idDoctor", "fullname", doctor_has_Patient.Doctor_idDoctor);
            ViewBag.Patient_idPatient = new SelectList(db.Patient, "idPatient", "fullname", doctor_has_Patient.Patient_idPatient);
            return View(doctor_has_Patient);
        }

        // GET: Doctor_has_Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_has_Patient doctor_has_Patient = db.Doctor_has_Patient.Find(id);
            if (doctor_has_Patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.Doctor_idDoctor = new SelectList(db.Doctor, "idDoctor", "fullname", doctor_has_Patient.Doctor_idDoctor);
            ViewBag.Patient_idPatient = new SelectList(db.Patient, "idPatient", "fullname", doctor_has_Patient.Patient_idPatient);
            return View(doctor_has_Patient);
        }

        // POST: Doctor_has_Patient/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Doctor_idDoctor,Patient_idPatient,datee,price")] Doctor_has_Patient doctor_has_Patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor_has_Patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Doctor_idDoctor = new SelectList(db.Doctor, "idDoctor", "fullname", doctor_has_Patient.Doctor_idDoctor);
            ViewBag.Patient_idPatient = new SelectList(db.Patient, "idPatient", "fullname", doctor_has_Patient.Patient_idPatient);
            return View(doctor_has_Patient);
        }

        // GET: Doctor_has_Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor_has_Patient doctor_has_Patient = db.Doctor_has_Patient.Find(id);
            if (doctor_has_Patient == null)
            {
                return HttpNotFound();
            }
            return View(doctor_has_Patient);
        }

        // POST: Doctor_has_Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor_has_Patient doctor_has_Patient = db.Doctor_has_Patient.Find(id);
            db.Doctor_has_Patient.Remove(doctor_has_Patient);
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
