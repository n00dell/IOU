using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class Student : User
    {
        public string StudentId {  get; set; }
        public string Course {  get; set; }
        public int Year { get; set; }
        public List<Guardian> Guardians { get; set; }
        public List<Debt> Debts { get; set; }
    }
}
