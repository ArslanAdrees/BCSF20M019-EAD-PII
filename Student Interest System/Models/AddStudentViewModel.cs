
using Student_Interest_System.Models.Domain;

namespace Student_Interest_System.Models
{
    public class AddStudentViewModel
    {
        public string Name { get; set; }
        public string Rollno { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Interest { get; set; }
        public string Department { get; set; }
        public string DegreeTitle { get; set; }
        public string Subject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<AddStudentViewModel> StudentsList { get; set; }
    }
}
