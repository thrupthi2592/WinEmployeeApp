using EmployeeDetails.BusinessLogic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace EmployeeDetails.Common
{
    public class EmployeeInfoPresenter
    {
        private readonly IEmployee _employee;
        public EmployeeInfoPresenter(IEmployee employee)
        {
            _employee = employee;
            _employee.SaveAttempted += _employee_SaveAttempted;
            _employee.UpdateAttempted += _employee_UpdateAttempted;
            _employee.DeleteAttempted += _employee_DeleteAttempted;
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

        private void _employee_UpdateAttempted(object? sender, EventArgs e)
        {
            _employee.ShowFormError = false;
            _employee.ErrorMessage = null;
            string allowedIDValues = "^[0-9]+$";
            if (string.IsNullOrEmpty(_employee.ID))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nID cannot be empty";
            }
            if (string.IsNullOrEmpty(_employee.Name) && string.IsNullOrEmpty(_employee.Email) && string.IsNullOrEmpty(_employee.Gender) && string.IsNullOrEmpty(_employee.Status))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nPlease fill in all the fields to update the details based on ID";
            }
            if (!string.IsNullOrEmpty(_employee.Email) && !_employee.Email.Contains("@"))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nEmail must contain @ symbol";
            }
            if (!Regex.IsMatch(_employee.ID, allowedIDValues))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nEnter a integer value for ID field";
            }
        }

        private void _employee_DeleteAttempted(object? sender, EventArgs e)
        {
            _employee.ShowFormError = false;
            _employee.ErrorMessage = null;
            string allowedIDValues = "^[0-9]+$";
            if (string.IsNullOrEmpty(_employee.ID))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nID cannot be empty";
            }
            if (!Regex.IsMatch(_employee.ID, allowedIDValues))
            {
                _employee.ShowFormError = true;
                _employee.ErrorMessage += "\nEnter a integer value for ID field";
            }
        }
    }
}
