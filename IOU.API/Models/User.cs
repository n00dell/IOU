namespace IOU.API.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; }
    }
    public enum UserType
    {
        Student,
        Guardian,
        Lender,
        Administrator
    }
}
