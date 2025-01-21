using System.ComponentModel.DataAnnotations;

namespace IOU.API.Models
{
    public class Guardian : User
    {
        public List<Student> Students { get; set; }
        public List<StudentGuardian> StudentGuardian { get; set; }
    }
}
