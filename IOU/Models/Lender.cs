
namespace IOU.Models
{
    class Lender: User
    {
        public string CompanyName { get; set; }
        public string BusinessRegistrationNumber { get; set; }
        public List<Debt> IssuedDebts { get; set; }
    }
}
