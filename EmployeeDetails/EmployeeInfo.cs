using EmployeeDetails.BusinessLogic;
using EmployeeDetails.Common;
using System.Net;

namespace EmployeeDetails
{
    public partial class EmployeeInfo : Form, IEmployee
    {
        private EmployeeInfoPresenter _presenter;


        //int IEmployee.ID { get => this.txtID.Text; set => this.txtID.Text = value; }
        string IEmployee.Name { get => this.txtFirstName.Text; set => this.txtFirstName.Text = value; }
        string IEmployee.Email { get => this.txtEmail.Text; set => this.txtEmail.Text = value; }
        string IEmployee.Gender { get => this.txtGender.Text; set => this.txtGender.Text = value; }
        string IEmployee.Status { get => this.txtStatus.Text; set => this.txtStatus.Text = value; }
        string IEmployee.ErrorMessage { get => this.lblError.Text; set => this.lblError.Text = value; }
        bool IEmployee.ShowFormError { get => this.lblError.Visible; set => this.lblError.Visible = value; }

        public event EventHandler? SaveAttempted;

        public EmployeeInfo()
        {
            InitializeComponent();
            this._presenter = new EmployeeInfoPresenter(this);
        }



        private void EmployeeInfo_Load(object sender, EventArgs e)
        {

        }
        private async void btnGetAllEmployees_Click(object sender, EventArgs e)
        {
            try
            {
                var response = await WebAPIEmployeeInfo.GetAllEmployeeDetails(txtPage.Text);
                txtResponse.Text = WebAPIEmployeeInfo.ConvertToJSONFormat(response);
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
                    var response = await WebAPIEmployeeInfo.GetSpecificEmployeeDetails(txtFirstName.Text, txtID.Text);
                    txtResponse.Text = WebAPIEmployeeInfo.ConvertToJSONFormat(response);
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
                WebAPIEmployeeInfo web = new WebAPIEmployeeInfo();
                var response = await web.InsertEmployeeDetails(txtFirstName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text, "json");
                txtResponse.Text = WebAPIEmployeeInfo.ConvertToJSONFormat(response);
                SaveAttempted?.Invoke(sender: this, e: EventArgs.Empty);
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
                WebAPIEmployeeInfo web = new WebAPIEmployeeInfo();
                var response = await web.UpdateEmployeeDetails(txtID.Text, txtFirstName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text,"json");
                txtResponse.Text = WebAPIEmployeeInfo.ConvertToJSONFormat(response);
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
                WebAPIEmployeeInfo web = new WebAPIEmployeeInfo();
                var response = await web.DeleteEmployeeDetails(txtID.Text, "json");
                txtResponse.Text = WebAPIEmployeeInfo.ConvertToJSONFormat(response);
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
