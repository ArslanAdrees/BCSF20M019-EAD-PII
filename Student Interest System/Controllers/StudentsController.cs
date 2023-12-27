using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Interest_System.Data;
using Student_Interest_System.Models;
using Student_Interest_System.Models.Domain;
namespace Student_Interest_System.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentInterestDbContext db;
        public StudentsController(StudentInterestDbContext db)
        {

            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await db.Students.ToListAsync();
            return View(students);

        }

        [HttpGet]
        public IActionResult Add()
        {

            var students = db.Students.ToList();

            // Create an instance of AddStudentViewModel
            var viewModel = new AddStudentViewModel
            {
                StudentsList = new List<AddStudentViewModel>()
            };

            // Populate the StudentsList property with data from the database
            foreach (var student in students)
            {
                viewModel.StudentsList.Add(new AddStudentViewModel
                {

                    Name = student.Name,
                    Rollno = student.Rollno,
                    Email = student.Email,
                    Gender = student.Gender,
                    DateOfBirth = student.DateOfBirth,
                    City = student.City,
                    Interest = student.Interest,
                    Department = student.Department,
                    DegreeTitle = student.DegreeTitle,
                    Subject = student.Subject,
                    StartDate = student.StartDate,
                    EndDate = student.EndDate

                });
            }
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel addStudentRequest)
        {
            var student = new Student()
            {
                Name = addStudentRequest.Name,
                Rollno = addStudentRequest.Rollno,
                Email = addStudentRequest.Email,
                Gender = addStudentRequest.Gender,
                DateOfBirth = addStudentRequest.DateOfBirth,
                City = addStudentRequest.City,
                Interest = addStudentRequest.Interest,
                Department = addStudentRequest.Department,
                DegreeTitle = addStudentRequest.DegreeTitle,
                Subject = addStudentRequest.Subject,
                StartDate = addStudentRequest.StartDate,
                EndDate = addStudentRequest.EndDate

            };
            
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewStudent(int id)
        {
            var student = await db.Students.FirstOrDefaultAsync(x=>x.Id==id);
            if(student!=null)
            {
                var viewModel = new UpdateStudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    Rollno = student.Rollno,
                    Email = student.Email,
                    Gender = student.Gender,
                    DateOfBirth = student.DateOfBirth,
                    City = student.City,
                    Interest = student.Interest,
                    Department = student.Department,
                    DegreeTitle = student.DegreeTitle,
                    Subject = student.Subject,
                    StartDate = student.StartDate,
                    EndDate = student.EndDate
                };
                return View(viewModel);
            }
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ViewStudent(UpdateStudentViewModel model)
        {
            var student = await db.Students.FindAsync(model.Id);
            if (student != null)
            {
                student.Name = model.Name;
                student.Rollno = model.Rollno;
                student.Email = model.Email;
                student.Gender = model.Gender;
                student.DateOfBirth = model.DateOfBirth;
                student.City = model.City;
                student.Interest = model.Interest;
                student.Department = model.Department;
                student.DegreeTitle = model.DegreeTitle;
                student.Subject = model.Subject;
                student.StartDate = model.StartDate;
                student.EndDate = model.EndDate;

                await db.SaveChangesAsync();
               return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(UpdateStudentViewModel model)
        {
            var student = await db.Students.FindAsync(model.Id);
            if (student != null)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var students = await db.Students.ToListAsync();
            return View(students);
        }


    }
}
