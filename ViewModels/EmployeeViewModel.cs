using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public bool Permanent { get; set; }
    }
}
