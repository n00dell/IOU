namespace IOU.API.Models
{
    public class Guardian : User
    {
        public List<Student> Students { get; set; }
        public string Relationship { get; set; }
    }
}
