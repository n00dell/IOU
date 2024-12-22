namespace IOU.API.Models
{
    public class Student : User
    {
        public string StudentId { get; set; }
        public string Course { get; set; }
        public int Year { get; set; }
        public List<Guardian> Guardians { get; set; }
        public List<Debt> Debts { get; set; }
    }
}
