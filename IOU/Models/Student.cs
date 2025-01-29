
namespace IOU.Models
{
    public class Student: User
    {
        public string StudentId { get; set; }
        public string University { get; set; }
        public DateTime ExpectedGraduationDate { get; set; }
        public List<StudentGuardian>? StudentGuardians { get; set; }
        public List<Debt>? Debts { get; set; }
    }
}
