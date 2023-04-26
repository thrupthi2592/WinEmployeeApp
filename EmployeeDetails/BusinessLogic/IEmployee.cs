using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.BusinessLogic
{
    public interface IEmployee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public bool  ShowFormError  { get; set; }

        public event EventHandler SaveAttempted;
        public event EventHandler UpdateAttempted;
        public event EventHandler DeleteAttempted;
    }
}
