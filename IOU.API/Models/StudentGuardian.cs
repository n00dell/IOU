using System.ComponentModel.DataAnnotations;

namespace IOU.API.Models
{
    public class StudentGuardian
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string StudentId {  get; set; }
        public Student Student { get; set; }
        [Required]
        public string GuardianId {  get; set; }
        public Guardian Guardian { get; set; }


    }
}
