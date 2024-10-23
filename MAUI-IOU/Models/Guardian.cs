using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class Guardian: User
    {
        public List<Student> Students { get; set; }
        public string Relationship { get; set; }

    }
}
