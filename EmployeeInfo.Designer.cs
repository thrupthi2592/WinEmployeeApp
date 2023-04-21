namespace EmployeeDetails
{
    partial class EmployeeInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGetAllEmployees = new Button();
            btnGetSpecificEmployee = new Button();
            btnCreate = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtResponse = new RichTextBox();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            txtGender = new TextBox();
            txtStatus = new TextBox();
            lblGender = new Label();
            lblEmail = new Label();
            lblStatus = new Label();
            lblName = new Label();
            lblID = new Label();
            txtID = new TextBox();
            btnInsertEmpDetails = new Button();
            btnUpdateEmpDetails = new Button();
            btnDeleteEmpDetails = new Button();
            btnGet = new Button();
            lblPage = new Label();
            txtPage = new TextBox();
            btnGetAll = new Button();
            SuspendLayout();
            // 
            // btnGetAllEmployees
            // 
            btnGetAllEmployees.Location = new Point(682, 32);
            btnGetAllEmployees.Name = "btnGetAllEmployees";
            btnGetAllEmployees.Size = new Size(104, 26);
            btnGetAllEmployees.TabIndex = 0;
            btnGetAllEmployees.Text = "GetAll";
            btnGetAllEmployees.UseVisualStyleBackColor = true;
            btnGetAllEmployees.Visible = false;
            btnGetAllEmployees.Click += btnGetAllEmployees_Click;
            // 
            // btnGetSpecificEmployee
            // 
            btnGetSpecificEmployee.Location = new Point(682, 133);
            btnGetSpecificEmployee.Name = "btnGetSpecificEmployee";
            btnGetSpecificEmployee.Size = new Size(104, 26);
            btnGetSpecificEmployee.TabIndex = 1;
            btnGetSpecificEmployee.Text = "Get";
            btnGetSpecificEmployee.UseVisualStyleBackColor = true;
            btnGetSpecificEmployee.Visible = false;
            btnGetSpecificEmployee.Click += btnGetSpecificEmployee_Click;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(682, 186);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(104, 24);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Visible = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(682, 237);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(104, 27);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(682, 77);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(104, 26);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtResponse
            // 
            txtResponse.Location = new Point(55, 368);
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(731, 207);
            txtResponse.TabIndex = 6;
            txtResponse.Text = "";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(413, 136);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(193, 23);
            txtFirstName.TabIndex = 7;
            txtFirstName.Visible = false;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(413, 188);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 23);
            txtEmail.TabIndex = 9;
            txtEmail.Visible = false;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(413, 243);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(193, 23);
            txtGender.TabIndex = 10;
            txtGender.Visible = false;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(413, 301);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(193, 23);
            txtStatus.TabIndex = 11;
            txtStatus.Visible = false;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(325, 246);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(45, 15);
            lblGender.TabIndex = 13;
            lblGender.Text = "Gender";
            lblGender.Visible = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(334, 188);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            lblEmail.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(331, 304);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "Status";
            lblStatus.Visible = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(331, 139);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 17;
            lblName.Text = "Name";
            lblName.Visible = false;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(352, 88);
            lblID.Name = "lblID";
            lblID.Size = new Size(18, 15);
            lblID.TabIndex = 18;
            lblID.Text = "ID";
            lblID.Visible = false;
            // 
            // txtID
            // 
            txtID.Location = new Point(413, 85);
            txtID.Name = "txtID";
            txtID.Size = new Size(193, 23);
            txtID.TabIndex = 19;
            txtID.Visible = false;
            // 
            // btnInsertEmpDetails
            // 
            btnInsertEmpDetails.Location = new Point(55, 165);
            btnInsertEmpDetails.Name = "btnInsertEmpDetails";
            btnInsertEmpDetails.Size = new Size(193, 38);
            btnInsertEmpDetails.TabIndex = 20;
            btnInsertEmpDetails.Text = "CreateEmployee";
            btnInsertEmpDetails.UseVisualStyleBackColor = true;
            btnInsertEmpDetails.Click += btnInsertEmpDetails_Click;
            // 
            // btnUpdateEmpDetails
            // 
            btnUpdateEmpDetails.Location = new Point(55, 231);
            btnUpdateEmpDetails.Name = "btnUpdateEmpDetails";
            btnUpdateEmpDetails.Size = new Size(193, 38);
            btnUpdateEmpDetails.TabIndex = 21;
            btnUpdateEmpDetails.Text = "UpdateEmployee";
            btnUpdateEmpDetails.UseVisualStyleBackColor = true;
            btnUpdateEmpDetails.Click += btnUpdateEmpDetails_Click;
            // 
            // btnDeleteEmpDetails
            // 
            btnDeleteEmpDetails.Location = new Point(55, 295);
            btnDeleteEmpDetails.Name = "btnDeleteEmpDetails";
            btnDeleteEmpDetails.Size = new Size(193, 38);
            btnDeleteEmpDetails.TabIndex = 22;
            btnDeleteEmpDetails.Text = "DeleteEmployee";
            btnDeleteEmpDetails.UseVisualStyleBackColor = true;
            btnDeleteEmpDetails.Click += btnDeleteEmpDetails_Click;
            // 
            // btnGet
            // 
            btnGet.Location = new Point(55, 99);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(193, 38);
            btnGet.TabIndex = 23;
            btnGet.Text = "GetSpecificEmployee";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(337, 35);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(33, 15);
            lblPage.TabIndex = 24;
            lblPage.Text = "Page";
            lblPage.Visible = false;
            // 
            // txtPage
            // 
            txtPage.Location = new Point(413, 32);
            txtPage.Name = "txtPage";
            txtPage.Size = new Size(68, 23);
            txtPage.TabIndex = 25;
            txtPage.Visible = false;
            // 
            // btnGetAll
            // 
            btnGetAll.Location = new Point(55, 32);
            btnGetAll.Name = "btnGetAll";
            btnGetAll.Size = new Size(193, 38);
            btnGetAll.TabIndex = 26;
            btnGetAll.Text = "GetAllEmployees";
            btnGetAll.UseVisualStyleBackColor = true;
            btnGetAll.Click += btnGetAll_Click;
            // 
            // EmployeeInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 587);
            Controls.Add(btnGetAll);
            Controls.Add(txtPage);
            Controls.Add(lblPage);
            Controls.Add(btnGet);
            Controls.Add(btnDeleteEmpDetails);
            Controls.Add(btnUpdateEmpDetails);
            Controls.Add(btnInsertEmpDetails);
            Controls.Add(txtID);
            Controls.Add(lblID);
            Controls.Add(lblName);
            Controls.Add(lblStatus);
            Controls.Add(lblEmail);
            Controls.Add(lblGender);
            Controls.Add(txtStatus);
            Controls.Add(txtGender);
            Controls.Add(txtEmail);
            Controls.Add(txtFirstName);
            Controls.Add(txtResponse);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(btnGetSpecificEmployee);
            Controls.Add(btnGetAllEmployees);
            Name = "EmployeeInfo";
            Text = "EmployeeDetails";
            Load += EmployeeInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetAllEmployees;
        private Button btnGetSpecificEmployee;
        private Button btnCreate;
        private Button btnUpdate;
        private Button btnDelete;
        private RichTextBox txtResponse;
        private TextBox txtFirstName;
        private TextBox txtEmail;
        private TextBox txtGender;
        private TextBox txtStatus;
        private Label lblGender;
        private Label lblEmail;
        private Label lblStatus;
        private Label lblName;
        private Label lblID;
        private TextBox txtID;
        private Button btnInsertEmpDetails;
        private Button btnUpdateEmpDetails;
        private Button btnDeleteEmpDetails;
        private Button btnGet;
        private Label lblPage;
        private TextBox txtPage;
        private Button btnGetAll;
    }
}