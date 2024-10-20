using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_IOU.Models
{
    internal class Lender: User
    {
        public string CompanyName {  get; set; }
        public string BusinessRegistrationNumber { get; set; }
        public List<Debt> IssuedDebts { get; set; }
    }
}
