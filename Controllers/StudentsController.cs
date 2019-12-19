using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExamples.Models;
using EntityFrameworkExamples.Models.ViewModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Bogus;

namespace EntityFrameworkExamples.Controllers
{
    public class StudentsController : Controller
    {
        private readonly EntityFrameworkExamplesContext _context;
        private readonly IMapper mapper;
        private Faker faker;

        public StudentsController(EntityFrameworkExamplesContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            faker = new Faker("sv");
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            //var model = await _context.Students
            //                .Include(s => s.Address)
            //                .Select(s => new StudentListViewModel
            //                {
            //                    Id = s.Id,
            //                    Avatar = s.Avatar,
            //                    FullName = s.FullName,
            //                    City = s.Address.City,
            //                    Street = s.Address.Street,
            //                    ZipCode = s.Address.ZipCode
            //                })
            //                .ToListAsync();

            //var model = await _context.Students.ProjectTo<StudentListViewModel>(mapper.ConfigurationProvider).ToListAsync();

            //var model2 = mapper.Map<IEnumerable<StudentListViewModel>>(_context.Students.Include(s => s.Address));

            var dto = mapper.Map<IEnumerable<StudentDTO>>(_context.Students.Where(s => s.Email.StartsWith("D")).ToList());

            var dto2 = mapper.ProjectTo<StudentDTO>(_context.Students.Where(s => s.Email.StartsWith("D"))).ToList();

            var model3 = await mapper.ProjectTo<StudentListViewModel>(_context.Students).ToListAsync();

            return View(model3);
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await mapper.ProjectTo<StudentDetailsViewModel>(_context.Students)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StudentAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Avatar = faker.Internet.Avatar(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = new Address
                    {
                        Street = model.Street,
                        City = model.City,
                        ZipCode = model.ZipCode
                    }
                };

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
