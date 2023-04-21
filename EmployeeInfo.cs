using EmployeeDetails.BusinessLogic;

namespace EmployeeDetails
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {

        }
        private async void btnGetAllEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await WebAPI.GetAllEmployeeDetails(txtPage.Text);
                txtResponse.Text = WebAPI.ConvertToJSONFormat(response);
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private async void btnGetSpecificEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtFirstName.Text) && string.IsNullOrEmpty(txtID.Text)) || (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtID.Text)))
                {
                    MessageBox.Show("Please enter any one value");
                }
                else if (!string.IsNullOrEmpty(txtFirstName.Text) || !string.IsNullOrEmpty(txtID.Text))
                {
                    var response = await WebAPI.GetSpecificEmployeeDetails(txtFirstName.Text, txtID.Text);
                    txtResponse.Text = WebAPI.ConvertToJSONFormat(response);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtGender.Text) && !string.IsNullOrEmpty(txtStatus.Text))
                {
                    var response = await WebAPI.InsertEmployeeDetails(txtFirstName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text);
                    txtResponse.Text = WebAPI.ConvertToJSONFormat(response);
                }
                else
                {
                    MessageBox.Show("Please enter all the fields to create the Employee details");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtGender.Text) && !string.IsNullOrEmpty(txtStatus.Text))
                {
                    var response = await WebAPI.UpdateEmployeeDetails(txtID.Text, txtFirstName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text);
                    txtResponse.Text = WebAPI.ConvertToJSONFormat(response);
                }
                else
                {
                    MessageBox.Show("Please enter all the fields to update the Employee details");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtID.Text))
                {
                    var response = await WebAPI.DeleteEmployeeDetails(txtID.Text);
                    txtResponse.Text = WebAPI.ConvertToJSONFormat(response);
                }
                else
                {
                    MessageBox.Show("Please enter the ID to delete the Employee details");
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFieldVisibility("Get");
                ClearFieldValues();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void btnGetAll_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFieldVisibility("GetAll");
                ClearFieldValues();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void btnInsertEmpDetails_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFieldVisibility("Create");
                ClearFieldValues();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void btnUpdateEmpDetails_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFieldVisibility("Update");
                ClearFieldValues();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void btnDeleteEmpDetails_Click(object sender, EventArgs e)
        {
            try
            {
                CheckFieldVisibility("Delete");
                ClearFieldValues();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }


        private void CheckFieldVisibility(string flag)
        {
            try
            {
                switch (flag)
                {
                    case "GetAll":
                        displayFields(false);
                        lblPage.Visible = true;
                        txtPage.Visible = true;
                        btnGetAllEmployees.Visible = true;
                        lblID.Visible = false;
                        lblName.Visible = false;
                        txtFirstName.Visible = false;
                        txtID.Visible = false;
                        txtResponse.Visible = true;
                        btnDelete.Visible = false;
                        break;
                    case "Get":
                        lblID.Visible = true;
                        lblName.Visible = true;
                        txtFirstName.Visible = true;
                        txtID.Visible = true;
                        txtResponse.Visible = true;
                        lblPage.Visible = false;
                        txtPage.Visible = false;
                        btnGetSpecificEmployee.Visible = true;
                        btnDelete.Visible = false;
                        displayFields(false);
                        btnGetAllEmployees.Visible = false;
                        break;
                    case "Create":
                        displayFields(true);
                        lblID.Visible = false;
                        txtID.Visible = false;
                        btnCreate.Visible = true;
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnGetSpecificEmployee.Visible = false;
                        btnGetAllEmployees.Visible = false;
                        break;
                    case "Update":
                        lblID.Visible = true;
                        txtID.Visible = true;
                        displayFields(true);
                        btnUpdate.Visible = true;
                        btnCreate.Visible = false;
                        btnDelete.Visible = false;
                        btnGetSpecificEmployee.Visible = false;
                        btnGetAllEmployees.Visible = false;
                        break;
                    case "Delete":
                        lblID.Visible = true;
                        txtID.Visible = true;
                        txtResponse.Visible = true;
                        lblPage.Visible = false;
                        txtPage.Visible = false;
                        btnDelete.Visible = true;
                        displayFields(false);
                        txtFirstName.Visible = false;
                        btnGetSpecificEmployee.Visible = false;
                        btnGetAllEmployees.Visible = false;
                        lblName.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void displayFields(bool display)
        {
            try
            {
                if (display.Equals(true))
                {
                    lblPage.Visible = false;
                    lblName.Visible = true;
                    lblEmail.Visible = true;
                    lblGender.Visible = true;
                    lblStatus.Visible = true;
                    txtPage.Visible = false;
                    txtFirstName.Visible = true;
                    txtEmail.Visible = true;
                    txtGender.Visible = true;
                    txtStatus.Visible = true;
                    txtResponse.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnCreate.Visible = false;
                    lblEmail.Visible = false;
                    lblGender.Visible = false;
                    lblStatus.Visible = false;
                    txtEmail.Visible = false;
                    txtGender.Visible = false;
                    txtStatus.Visible = false;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

        private void ClearFieldValues()
        {
            try
            {
                txtID.Clear();
                txtFirstName.Clear();
                txtGender.Clear();
                txtEmail.Clear();
                txtStatus.Clear();
                txtPage.Clear();
                txtResponse.Clear();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", ex.ToString());
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionhandler.UnhandledException);
            }
        }

    }
}
