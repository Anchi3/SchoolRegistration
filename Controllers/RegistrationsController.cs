using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolRegistration.Models;

namespace SchoolRegistration.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly MVCRegistrationContext _context;

        public RegistrationsController(MVCRegistrationContext context)
        {
            _context = context;
        }

        // GET: Registrations
        public async Task<IActionResult> Index()
        {
            var mVCRegistrationContext = _context.Registration.Include(r => r.Course).Include(r => r.Instructor).Include(r => r.Student).Include(r => r.StudentTypeNavigation);
            return View(await mVCRegistrationContext.ToListAsync());
        }

        // GET: Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .Include(r => r.Course)
                .Include(r => r.Instructor)
                .Include(r => r.Student)
                .Include(r => r.StudentTypeNavigation)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Registrations/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "EmailAddress");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName");
            ViewData["StudentType"] = new SelectList(_context.RegType, "StudentType", "RegisterType");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistrationId,StudentType,StudentId,CourseId,InstructorId")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "EmailAddress", registration.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", registration.StudentId);
            ViewData["StudentType"] = new SelectList(_context.RegType, "StudentType", "RegisterType", registration.StudentType);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "EmailAddress", registration.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", registration.StudentId);
            ViewData["StudentType"] = new SelectList(_context.RegType, "StudentType", "RegisterType", registration.StudentType);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistrationId,StudentType,StudentId,CourseId,InstructorId")] Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.RegistrationId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", registration.CourseId);
            ViewData["InstructorId"] = new SelectList(_context.Instructor, "InstructorId", "EmailAddress", registration.InstructorId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FirstName", registration.StudentId);
            ViewData["StudentType"] = new SelectList(_context.RegType, "StudentType", "RegisterType", registration.StudentType);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registration
                .Include(r => r.Course)
                .Include(r => r.Instructor)
                .Include(r => r.Student)
                .Include(r => r.StudentTypeNavigation)
                .FirstOrDefaultAsync(m => m.RegistrationId == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registration.FindAsync(id);
            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registration.Any(e => e.RegistrationId == id);
        }
    }
}
