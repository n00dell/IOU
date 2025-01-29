using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOU.Models
{
   public  class Guardian: User
    {
        public List<Student> Students { get; set; }
        public List<StudentGuardian> StudentGuardian { get; set; }
    }
}
