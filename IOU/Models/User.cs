using System.ComponentModel.DataAnnotations;

namespace IOU.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
    public enum UserType
    {
        None,
        Student,
        Guardian,
        Lender,
        Administrator
    }
}

