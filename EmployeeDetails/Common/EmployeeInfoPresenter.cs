using EmployeeDetails.BusinessLogic;

namespace EmployeeDetails.Common
{
    public class EmployeeInfoPresenter
    {
        private readonly IEmployee _employee;
        public EmployeeInfoPresenter(IEmployee employee)
        {
            _employee = employee;
            _employee.SaveAttempted += _employee_SaveAttempted;
        }

        private void _employee_SaveAttempted(object? sender, EventArgs e)
        {
            _employee.ShowFormError = false;
            _employee.ErrorMessage = null;
            if (string.IsNullOrEmpty(_employee.Name))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nName cannot be empty";
            }
            if (string.IsNullOrEmpty(_employee.Email))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nEmail cannot be empty";
            }
            if (!string.IsNullOrEmpty(_employee.Email) && !_employee.Email.Contains("@"))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nEmail must contain @ symbol";
            }
            if (string.IsNullOrEmpty(_employee.Gender))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nGender cannot be empty";
            }
            if (string.IsNullOrEmpty(_employee.Status))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nStatus cannot be empty";
            }
        }
    }
}
