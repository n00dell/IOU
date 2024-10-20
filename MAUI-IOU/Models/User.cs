using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class User
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public string PhoneNumber {  get; set; }

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
